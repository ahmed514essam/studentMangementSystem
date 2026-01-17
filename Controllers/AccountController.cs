using Microsoft.AspNetCore.Mvc;
using studentMangementSystem.Data;

namespace studentMangementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext context;

        public AccountController(AppDbContext context)
        {
            this.context = context;
        }

        // GET
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // ================= ADMIN LOGIN =================
            var admin = context.Admin.FirstOrDefault(a => a.Email == model.Email);
            if (admin != null &&
                PasswordHasher.Verify(model.Password, admin.PasswordHash))
            {
                HttpContext.Session.SetString("Role", "Admin");
                HttpContext.Session.SetInt32("AdminId", admin.Id);

                return RedirectToAction("Dashboard", "AdminPanel");
            }

            // ================= STUDENT LOGIN =================
            var student = context.Students.FirstOrDefault(s => s.Email == model.Email);
            if (student != null &&
                PasswordHasher.Verify(model.Password, student.PasswordHash))
            {
                HttpContext.Session.SetString("Role", "Student");
                HttpContext.Session.SetInt32("StudentId", student.Id);

                return RedirectToAction("UserPanel", "User");
            }

            ModelState.AddModelError("", "Invalid Email or Password");
            return View(model);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

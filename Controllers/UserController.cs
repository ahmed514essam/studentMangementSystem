using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentMangementSystem.Data;
using studentMangementSystem.Models;

namespace studentMangementSystem.Controllers
{
    [StudentAuthorize]
    public class UserController : Controller
    {
        private readonly AppDbContext context;
        public UserController(AppDbContext context)
        {
            this.context = context;
        }


        public async Task<IActionResult> UserPanel()
        {
            int studentId = HttpContext.Session.GetInt32("StudentId") ?? 0;
            if (studentId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            var student = await context.Students
    .Include(s => s.Department)
    .Include(s => s.StudyYear)
    .Include(s => s.Sport)
    .Include(s => s.Status)
    .Include(s => s.StudentSubjects)
        .ThenInclude(ss => ss.Subject)
    .FirstOrDefaultAsync(s => s.Id == studentId);
            if (student == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(student);
        }



        public async Task<IActionResult> RegisterSubjects()
        {
            var studentId = HttpContext.Session.GetInt32("StudentId") ?? 0;
            if (studentId == 0)
            {
                return RedirectToAction("Login", "Account");
            }

            var student = await context.Students
                .Include(s => s.StudentSubjects)
                .FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null)
                return NotFound();

            var subjects = await context.Subjects
                .Where(s =>
                    s.DepartmentId == student.DepartmentId &&
                    s.StudyYearId == student.StudyYearId
                )
                .ToListAsync();

            ViewBag.Subjects = subjects; // ✔ List حقيقية
            return View(student);
        }



        [HttpPost]
        [StudentAuthorize]
        public async Task<IActionResult> RegisterSubjects(List<int> subjectIds)
        {
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
                return RedirectToAction("Login", "Account");

            // منع التكرار
            var existing = context.StudentSubjects
                .Where(ss => ss.StudentId == studentId)
                .Select(ss => ss.SubjectId)
                .ToList();

            var newSubjects = subjectIds
                .Where(id => !existing.Contains(id))
                .Select(id => new StudentSubject
                {
                    StudentId = studentId.Value,
                    SubjectId = id
                });

            context.StudentSubjects.AddRange(newSubjects);
            await context.SaveChangesAsync();

            return RedirectToAction("UserPanel");  
        }



    }
}

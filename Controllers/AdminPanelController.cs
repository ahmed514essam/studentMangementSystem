using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentMangementSystem.Data;
using studentMangementSystem.Services;

namespace studentMangementSystem.Controllers
{
    [AdminAuthorize]
    public class AdminPanelController : Controller
    {
        private readonly AppDbContext context;
        public AdminPanelController(AppDbContext context)
        {
            this.context = context;
        }





        public async Task<IActionResult> Dashboard()
        {
            var studentsCount = context.Students.Count();
            ViewBag.StudentsCount = studentsCount;
            var departmentsCount = context.Departments.Count();
            ViewBag.DepartmentsCount = departmentsCount;
            var subjectsCount = context.Subjects.Count();
            ViewBag.SubjectsCount = subjectsCount;
            var studyYearsCount = context.StudyYears.Count();
            ViewBag.StudyYearsCount = studyYearsCount;

            var lastStudents = context.Students
                .OrderByDescending(s => s.InrollDate)
                .Take(5)
                .ToList();

            ViewBag.LastStudents = lastStudents;

            var topDepartments = context.Departments
                .Include(d => d.Students)
                .OrderByDescending(d => d.Students.Count)
                .Take(5)
                .ToList();
            ViewBag.TopDepartments = topDepartments;


            return View();
        }







    }
}

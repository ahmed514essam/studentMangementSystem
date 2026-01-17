using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using studentMangementSystem.Data;
using studentMangementSystem.Models;
using studentMangementSystem.Services;

namespace studentMangementSystem.Controllers
{
    [AdminAuthorize]

    public class SubjectController : Controller
    {
        private readonly SubjectServices subjectServices;
        private readonly AppDbContext context;
        public SubjectController(SubjectServices subjectServices , AppDbContext context)
        {
            this.subjectServices = subjectServices;
            this.context = context;
        }


        // Add Subject
        [HttpGet]
        public IActionResult AddSubject()
        {
            var department = context.Departments.ToList();
            ViewBag.Departments = department;
            var studyYear = context.StudyYears.ToList();
            ViewBag.StudyYears = studyYear;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSubject(Subject subject)
        {
            var department = context.Departments.ToList();
            ViewBag.Departments = department;
            var studyYear = context.StudyYears.ToList();
            ViewBag.StudyYears = studyYear;

            var targetSubject = new Subject { 
            Id = subject.Id,
            Name = subject.Name,
            CreditHours = subject.CreditHours,
            SubjectDoctor = subject.SubjectDoctor,
            DeliveryOrder = subject.DeliveryOrder,
            Department = subject.Department,
            DepartmentId = subject.DepartmentId,
            StudyYear = subject.StudyYear,
            StudyYearId = subject.StudyYearId,
            StudentSubjects = subject.StudentSubjects,
            };
               
               
             subjectServices.AddSubject(targetSubject);

            return View();
        }


        //Get All Subjects
        public IActionResult Show()
        {
            var tarSubject = subjectServices.GetAllSubjects();
            return View(tarSubject);
        }


        // Edit Subject
        [HttpGet]
        public IActionResult EditSubject(int id)
        {
            var department = context.Departments.ToList();
            ViewBag.Departments = department;

            var studyYear = context.StudyYears.ToList();
            ViewBag.StudyYears = studyYear;

            var subject = subjectServices.FindSubjectById(id);
            if (subject == null)
                return NotFound();

            return View(subject);
        }


        [HttpPost]
        public async Task<IActionResult> EditSubject(Subject model)
        {
            await subjectServices.EditSubject(model);
            return RedirectToAction("Show");
        }




        //Remove Subject

        [HttpPost]
        public async Task<IActionResult> RemoveSubject(int id)
        {
            await  subjectServices.RemoveSubject(id);
            return RedirectToAction("Show");
        }







    }
}

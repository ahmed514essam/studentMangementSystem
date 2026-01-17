using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentMangementSystem.Data;
using studentMangementSystem.Models;
using studentMangementSystem.Services;

namespace studentMangementSystem.Controllers
{
    [AdminAuthorize]
    // Student Management Controller

    public class StudentMangementController : Controller
    {
        private readonly StudentMangement studentMangement;
        private readonly AppDbContext context;

        public StudentMangementController(StudentMangement studentMangement , AppDbContext context)
        {
            this.studentMangement = studentMangement;
            this.context = context;
        }


        public  IActionResult ShowStudents()
        { 
          var students =  studentMangement.GetAllStudents();
            return View(students);
        }


        

        public async Task<IActionResult> StudentDetails(int id)
        {
            var student = await studentMangement.GetStudentsByDetails(id);
            if (student == null)
            {
                return NotFound();
            }
            return  View(student);
        }




        public IActionResult AddStudent()
        {
            var department = context.Departments.ToList();
            ViewBag.Departments = department;
            var studyYear = context.StudyYears.ToList();
            ViewBag.StudyYears = studyYear;
            var sport = context.Sports.ToList();
            ViewBag.Sports = sport;
            var status = context.Statuses.ToList();
            ViewBag.Status = status;


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentVM dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = context.Departments.ToList();
                ViewBag.StudyYears = context.StudyYears.ToList();
                ViewBag.Sports = context.Sports.ToList();
                ViewBag.Status = context.Statuses.ToList();
                return View(dto);
            }

            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                InrollDate = dto.InrollDate,
                DepartmentId = dto.DepartmentId,
                StudyYearId = dto.StudyYearId,
                SportId = dto.SportId,
                StatusId = dto.StatusId,
                PasswordHash = PasswordHasher.Hash(dto.Password)
            };

            await studentMangement.AddStudentAsync(student);

            return RedirectToAction("ShowStudents");
        }



        private StudentDto MapToDto(Student s)
        {
            return new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Address = s.Address,
                PhoneNumber = s.PhoneNumber,
                InrollDate = s.InrollDate,

                DepartmentId = s.DepartmentId,
                StudyYearId = s.StudyYearId,
                SportId = s.SportId,
                StatusId = s.StatusId,

                DepartmentName = s.Department.Name,
                StudyYearName = s.StudyYear.Name,
                SportName = s.Sport.Name,
                StatusName = s.Status.Name
            };
        }




        public IActionResult EditStudent(int id)
        {
            var student = context.Students
                .Include(s => s.Department)
                .Include(s => s.StudyYear)
                .Include(s => s.Sport)
                .Include(s => s.Status)
                .FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            var dto = MapToDto(student);

            ViewBag.Departments = context.Departments.ToList();
            ViewBag.StudyYears = context.StudyYears.ToList();
            ViewBag.Sports = context.Sports.ToList();
            ViewBag.Status = context.Statuses.ToList();

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(StudentDto model)
        {
            var student = await context.Students.FindAsync(model.Id);
            if (student == null) return NotFound();

            student.Name = model.Name;
            student.Email = model.Email;
            student.Address = model.Address;
            student.PhoneNumber = model.PhoneNumber;
            student.InrollDate = model.InrollDate;

            student.DepartmentId = model.DepartmentId;
            student.StudyYearId = model.StudyYearId;
            student.SportId = model.SportId;
            student.StatusId = model.StatusId;

            await context.SaveChangesAsync();

            return RedirectToAction("ShowStudents");
        }




       
        [HttpPost]
        public async Task<IActionResult> DeleteStudent(Student dto)
        {
            var student = await studentMangement.DeleteStudent(dto.Id);
            return RedirectToAction("ShowStudents");
        }




    }
}

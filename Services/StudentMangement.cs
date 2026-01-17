using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using studentMangementSystem.Data;
using studentMangementSystem.Models;

namespace studentMangementSystem.Services
{
    public class StudentMangement
    {
        private readonly AppDbContext context;
        public StudentMangement(AppDbContext context)
        {
            this.context = context;
        }


        public Student FindById(int id)
        {
            var std = context.Students.FirstOrDefault(i => i.Id == id);
            return std;
        }

        public StudentDto MapToDto(Student student)
        {
            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Address = student.Address,
                PhoneNumber = student.PhoneNumber,
                InrollDate = student.InrollDate,
                DepartmentId = student.DepartmentId,
                StudyYearId = student.StudyYearId,
                SportId = student.SportId,
                StatusId = student.StatusId,
                DepartmentName = student.Department?.Name,
                StudyYearName = student.StudyYear?.Name,
                SportName = student.Sport?.Name,
                StatusName = student.Status?.Name
            };
        }



        public async Task<Student> AddStudentAsync(Student student)
        {
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> EditStudent(Student model)
        {
            var std = await context.Students.FirstOrDefaultAsync(s => s.Id == model.Id);

            if (std == null)
                throw new Exception("Student not found");

            std.Name = model.Name;
            std.Email = model.Email;
            std.Address = model.Address;
            std.PhoneNumber = model.PhoneNumber;
            std.DepartmentId = model.DepartmentId;
            std.StudyYearId = model.StudyYearId;
            std.SportId = model.SportId;
            std.StatusId = model.StatusId;

            await context.SaveChangesAsync();
            return std;
        }


        public async Task<bool> DeleteStudent(int id)
        {
            var std = await context.Students.FindAsync(id);

            if (std == null)
                return false;

            var studentSubjects = context.StudentSubjects.Where(ss => ss.StudentId == id);
            context.StudentSubjects.RemoveRange(studentSubjects);


            context.Students.Remove(std);
            await context.SaveChangesAsync();
            return true;
        }


        public IEnumerable<Student> GetAllStudents()
        {
            var studentFound = context.Students
      
      .ToList();


            return studentFound;
        }



        public async Task<Student> GetStudentsByDetails(int id)
        {
            var targetStudent = await context.Students
                .Include(s => s.Sport)
                .Include(s => s.Department)
                .Include(s => s.StudyYear)
                .Include(s => s.Status)
                .Include(s => s.StudentSubjects)
                    .ThenInclude(ss => ss.Subject)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (targetStudent == null)
            {
                throw new Exception("Student Not Found");
            }

            return targetStudent;
        }









    }
}

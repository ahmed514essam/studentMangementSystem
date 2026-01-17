using Microsoft.EntityFrameworkCore;
using studentMangementSystem.Data;
using studentMangementSystem.Models;

namespace studentMangementSystem.Services
{
    public class SubjectServices
    {
        private readonly AppDbContext context;

        public SubjectServices(AppDbContext context)
        {
            this.context = context;
        }


        public Subject FindSubjectById(int id)
        {
            var subject = context.Subjects.FirstOrDefault(s => s.Id == id);
            return subject;
        }

        public  Subject AddSubject(Subject subject)
        {
            var addedSubject = new Subject
            {
                Name = subject.Name,
                CreditHours = subject.CreditHours,
                SubjectDoctor = subject.SubjectDoctor,
                DeliveryOrder = subject.DeliveryOrder,
                DepartmentId = subject.DepartmentId,
                StudyYearId = subject.StudyYearId,
                Department = subject.Department,
                StudyYear = subject.StudyYear

            };

            context.Subjects.Add(addedSubject);
             context.SaveChanges();

            return addedSubject;
        }



        public IEnumerable<Subject> GetAllSubjects()
        {
            var subjects = context.Subjects.Include(s => s.Department)
                .Include(s => s.StudyYear)
                .Include(s => s.StudentSubjects)
                    .ThenInclude(ss => ss.Student)
                .ToList();
            return subjects;
        }


        public async Task<Subject> EditSubject(Subject model)
        {
            var subject = await context.Subjects.FirstOrDefaultAsync(s => s.Id == model.Id);

            if (subject == null)
                throw new Exception("Subject not found");

            subject.Name = model.Name;
            subject.CreditHours = model.CreditHours;
            subject.SubjectDoctor = model.SubjectDoctor;
            subject.DeliveryOrder = model.DeliveryOrder;
            subject.DepartmentId = model.DepartmentId;
            subject.StudyYearId = model.StudyYearId;

            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException("اسم المادة لا يمكن أن يكون فارغًا.");


            await context.SaveChangesAsync();
            return subject;
        }


        public async Task<Subject> RemoveSubject(int id)
        {
            var targetSubject = FindSubjectById(id);
            if (targetSubject == null)
            {
                throw new Exception("Student not found");

            }
             context.Subjects.Remove(targetSubject);
            await context.SaveChangesAsync();
            return targetSubject;
        }





    }
}

using Microsoft.EntityFrameworkCore;
using studentMangementSystem.Data;
using studentMangementSystem.Models;

namespace studentMangementSystem.Services
{
    public class DepartmentService
    {
        private readonly AppDbContext context;
        public DepartmentService(AppDbContext context)
        { this.context = context; }



        public  Department FindById(int id)
        {
            var dept =  context.Departments.Include(s => s.Subjects).Include(s => s.DepartmentStudyYears).FirstOrDefault(i => i.Id == id);
            return dept;
        }


        public IEnumerable<Department> GetAllDepartments()
        {
            var departments = context.Departments
                .Include(d => d.Students)
                .Include(d => d.Subjects)
                .AsSingleQuery()
                .ToList();
            return departments;
        }
        public Department GetAllDepartmentsMore(int id )
        {

            var targetDepartment = context.Departments
                .Include(d => d.Subjects)
                .Include(d => d.Students)
                .ThenInclude(ds => ds.StudentSubjects).ThenInclude(f => f.Subject)
                .AsSplitQuery()
                .FirstOrDefault(ad => ad.Id == id);
               
            return targetDepartment;
        }


        public Department AddDepartment(Department department)
        {
            var addedDepartment = new Department
            {
                Name = department.Name,
                DeliveryOrder = department.DeliveryOrder,
                DepartmentHead = department.DepartmentHead
            };

            context.Departments.Add(addedDepartment);
            context.SaveChanges(); // هنا بيتولد الـ Id

            var allYears = context.StudyYears.ToList();
            bool isEngineering = department.Name.Contains("Engineering") || department.Name.Contains("هندسة");

            List<DepartmentStudyYear> relations;

            if (isEngineering)
            {
                relations = allYears.Select(y => new DepartmentStudyYear
                {
                    DepartmentId = addedDepartment.Id,
                    StudyYearId = y.Id
                }).ToList();
            }
            else
            {
                relations = allYears.Where(r => r.Name != "Preparatory")
                    .Select(y => new DepartmentStudyYear
                    {
                        DepartmentId = addedDepartment.Id, // هنا التعديل المهم
                        StudyYearId = y.Id
                    }).ToList();
            }

            context.DepartmentStudyYears.AddRange(relations);
            context.SaveChanges();

            return addedDepartment;
        }

        public async Task<Department> EditDepartment(Department department)
        {
            var FoundDepartment = context.Departments.FirstOrDefaultAsync(f => f.Id == department.Id);
            if (FoundDepartment == null)
            {
                throw new Exception("Department not found");
            }
            FoundDepartment.Result.Name = department.Name;
            FoundDepartment.Result.DepartmentHead = department.DepartmentHead;
            FoundDepartment.Result.DeliveryOrder = department.DeliveryOrder;
            FoundDepartment.Result.Students = department.Students;
            FoundDepartment.Result.Subjects = department.Subjects;
            FoundDepartment.Result.DepartmentStudyYears = department.DepartmentStudyYears;
           
            await context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var dept = context.Departments
                .Include(d => d.DepartmentStudyYears)
                .FirstOrDefault(s => s.Id == id);

            if (dept == null)
                throw new Exception("Department not found");

            // احذف العلاقات أولًا
            context.DepartmentStudyYears.RemoveRange(dept.DepartmentStudyYears);

            // بعدين احذف القسم
            context.Departments.Remove(dept);
            await context.SaveChangesAsync();

            return true;
        }




    }
}

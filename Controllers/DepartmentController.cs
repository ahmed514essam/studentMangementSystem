using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using studentMangementSystem.Data;
using studentMangementSystem.Models;
using studentMangementSystem.Services;

namespace studentMangementSystem.Controllers
{
    [AdminAuthorize]

    public class DepartmentController : Controller
    {
        private readonly DepartmentService departmentService;
        public DepartmentController(DepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        //Show All Departments
        public IActionResult ShowAllDepartments()
        {
            var departments = departmentService.GetAllDepartments();

            return View(departments);
        }


        public IActionResult More(int id)
        {
            var departments = departmentService.GetAllDepartmentsMore(id);

            return View(departments);
        }
        [HttpPost]
        public IActionResult More(Subject subject)
        {
            var departments = departmentService.GetAllDepartmentsMore(subject.Id);

            return View(departments);
        }





        //Add Department
        public IActionResult AddDepartment(int id)
        {
            var department = departmentService.FindById(id);

            return View(department);
        }
        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            departmentService.AddDepartment(department);
            return View();
        }








        //Edit Department
        [HttpGet]
        public IActionResult EditDepartment(int id)
        {
            var department = departmentService.FindById(id);
            return View(department);
        }
        [HttpPost]
        public async Task<IActionResult> EditDepartment(Department department )
        {
            await departmentService.EditDepartment(department);
            return RedirectToAction("ShowAllDepartments");
        }




        [HttpPost]
        public async Task<IActionResult> RemoveDepartment(int id)
        {


            var tardep = departmentService.FindById(id);
            if (tardep == null)
            {
                return NotFound();
            }
            else
            {
                if (tardep.Subjects == null || !tardep.Subjects.Any())
                {
                    await departmentService.DeleteDepartment(id);
                    return RedirectToAction("ShowAllDepartments");


                }

                TempData["Warning"] = "Please note that all Subjects related to this Department must be removed before deleting the Department.";
                return RedirectToAction("ShowAllDepartments");

                // رجوع لصفحة عرض الأقسام
            }
        }



    }
}

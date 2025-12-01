using DemoSession3.BuisnessLogic.DataTransferObjects;
using DemoSession3.BuisnessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Session3Demo.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        public DepartmentController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }
        public IActionResult Index()
        {
            var departments = _departmentServices.GetAllDepartments();
            return View(departments);
        }
        //show the form 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto DepartmentDto)
        {
            if (ModelState.IsValid)
            {
                return View(DepartmentDto);
            }
            var masege = string.Empty;
            try
            {
                var result = _departmentServices.AddDepartment(DepartmentDto);
                if (result > 0)
                {
                    return View("index");
                }
                else
                {

                    masege = "dept can't be created";
                    ModelState.AddModelError(string.Empty, masege);

                }
            }
            catch { }
            return null ;
        }
    }
}
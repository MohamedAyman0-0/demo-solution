using DemoSession.BuisnessLogic.Services;
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
            return View();
        }
    }
}
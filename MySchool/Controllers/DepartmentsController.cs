using Microsoft.AspNetCore.Mvc;

namespace MySchool.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
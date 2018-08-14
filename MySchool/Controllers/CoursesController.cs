using Microsoft.AspNetCore.Mvc;

namespace MySchool.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
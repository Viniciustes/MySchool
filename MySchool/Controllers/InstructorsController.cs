using Microsoft.AspNetCore.Mvc;

namespace MySchool.Controllers
{
    public class InstructorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
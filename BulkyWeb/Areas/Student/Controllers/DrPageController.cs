using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Student.Controllers
{
    [Area("Student")]
    public class DrPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
    }
}

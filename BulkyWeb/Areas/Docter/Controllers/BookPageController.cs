using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Docter.Controllers
{
    [Area("Docter")]
    public class BookPageController : Controller
    {
        public IActionResult BookPage()
        {
            return View();
        }
    }
}

using BulkyBookDataAccess.Repositray.IRepositray;
using BulkyBookModels.Model;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Student.Controllers
{
    [Area("Student")]
    public class FeedbackController : Controller
    {
        private readonly IUnitOfWorkRepositray _UnitOfWorkRepositra;

        public FeedbackController(IUnitOfWorkRepositray UnitOfWorkRepositra)
        {
            _UnitOfWorkRepositra = UnitOfWorkRepositra;
        }
        [HttpGet]
        public IActionResult Feedback()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");

            var Data = new Feedback();

            Data.email = userEmail;
            

            return View(Data);
        }
        [HttpPost]
        public IActionResult Feedback(Feedback feedback)
        {
            _UnitOfWorkRepositra.Feedback.Add(feedback);
            _UnitOfWorkRepositra.Save();
            return Feedback();
        }
    }
}

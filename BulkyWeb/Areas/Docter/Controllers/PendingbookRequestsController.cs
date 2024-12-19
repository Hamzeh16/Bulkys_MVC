using BulkyBookDataAccess.Repositray.IRepositray;
using BulkyBookModels.Model;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Docter.Controllers
{
    [Area("Docter")]
    public class PendingbookRequestsController : Controller
    {
        private readonly IUnitOfWorkRepositray _UnitOfWorkRepositra;

        public PendingbookRequestsController(IUnitOfWorkRepositray categoryRepositray)
        {
            _UnitOfWorkRepositra = categoryRepositray;
        }

        // Display pending post requests
        public IActionResult PendingbookRequests()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail"); // For Docter Just
            List<BookingPagecs> objCategoryList = _UnitOfWorkRepositra.BookingPages.GetAll().ToList();
            objCategoryList = objCategoryList.Where(x => x.Requst == null && x.TypeUser == "Student" && x.User_Email == userEmail).ToList();
            return View(objCategoryList);
        }

        // Approve a post request
        [HttpPost]
        public IActionResult PendingbookRequests(BookingPagecs category, string action, int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            category = _UnitOfWorkRepositra.BookingPages.Get(c => c.ID == ID);
            if (category != null)
            {
                if (action == "approve")
                {
                    // Handle approve logic
                    category.Requst = true;
                }
                else if (action == "reject")
                {
                    // Handle reject logic
                    category.Requst = false;
                }
                _UnitOfWorkRepositra.BookingPages.Update(category);
                TempData["success"] = "Category Updated successfully";

                _UnitOfWorkRepositra.Save();
            }
            return View();
        }
    }
}

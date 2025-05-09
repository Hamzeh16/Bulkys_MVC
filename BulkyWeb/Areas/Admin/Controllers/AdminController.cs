using BulkyBookDataAccess.Repositray.IRepositray;
using BulkyBookModels.Model;
using BulkyBookUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AdminController : Controller
    {
        private readonly IUnitOfWorkRepositray _UnitOfWorkRepositra;

        public AdminController(IUnitOfWorkRepositray categoryRepositray)
        {
            _UnitOfWorkRepositra = categoryRepositray;
        }

        // Display pending post requests
        public IActionResult PendingPostRequests()
        {
            List<BookingPagecs> objCategoryList = _UnitOfWorkRepositra.BookingPages.GetAll().ToList();
            objCategoryList = objCategoryList.Where(x => x.Requst == null && x.TypeUser == "Student").ToList();
            return View(objCategoryList);
        }

        // Approve a post request
        [HttpPost]
        public IActionResult PendingPostRequests(BookingPagecs BookingPages, string action, int? ID)
        {
            if (ID == 0 || ID == null)
            {
                return NotFound();
            }
            BookingPages = _UnitOfWorkRepositra.BookingPages.Get(c => c.ID == ID);
            if (BookingPages != null)
            {
                if (action == "approve")
                {
                    // Handle approve logic
                    BookingPages.Requst = true;
                }
                else if (action == "reject")
                {
                    // Handle reject logic
                    BookingPages.Requst=false;
                }
                _UnitOfWorkRepositra.BookingPages.Update(BookingPages);
                TempData["success"] = "Category Updated successfully";

                _UnitOfWorkRepositra.Save();
            }
            return RedirectToAction("PendingPostRequests");
        }
    }
}

using BulkyBookDataAccess.Repositray.IRepositray;
using BulkyBookModels.Models;
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
            List<Category> objCategoryList = _UnitOfWorkRepositra.Category.GetAll().ToList();
            objCategoryList = objCategoryList.Where(x => x.IsAdded != x.IsApproved).ToList();
            return View(objCategoryList);
        }

        // Approve a post request
        [HttpPost]
        public IActionResult PendingPostRequests(Category category , string action, int? ID)
        {
            if (ID == 0 || ID == null)
            {
                return NotFound();
            }
            category = _UnitOfWorkRepositra.Category.Get(c => c.ID == ID);
            if (category != null)
            {
                if (action == "approve")
                {
                    // Handle approve logic
                    category.IsApproved = true;
                    category.IsAdded = true;
                }
                else if (action == "reject")
                {
                    // Handle reject logic
                    category.IsApproved=false;
                    category.IsAdded = false;
                }
                _UnitOfWorkRepositra.Category.Update(category);
                TempData["success"] = "Category Updated successfully";

                _UnitOfWorkRepositra.Save();
            }
            return RedirectToAction("PendingPostRequests");
        }
    }
}

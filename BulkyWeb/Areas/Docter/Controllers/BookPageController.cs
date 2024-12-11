using BulkyBookDataAccess.Repositray.IRepositray;
using BulkyBookModels.Model;
using BulkyBookModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Docter.Controllers
{
    [Area("Docter")]
    public class BookPageController : Controller
    {
        private readonly IUnitOfWorkRepositray _UnitOfWorkRepositra;
        public BookPageController(IUnitOfWorkRepositray UnitOfWorkRepositra)
        {
            _UnitOfWorkRepositra = UnitOfWorkRepositra;
        }
        public IActionResult Index()
        {
            List<BookingPagecs> objBookingPageList = _UnitOfWorkRepositra.BookingPages.GetAll().ToList();
            return View(objBookingPageList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _UnitOfWorkRepositra.Category.Add(category);
            _UnitOfWorkRepositra.Save();
            TempData["success"] = "Category Created successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? ID)
        {
            if (ID == 0 || ID == null)
            {
                return NotFound();
            }
            Category? category = _UnitOfWorkRepositra.Category.Get(c => c.ID == ID);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWorkRepositra.Category.Update(category);
                TempData["success"] = "Category Updated successfully";

                _UnitOfWorkRepositra.Save();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? ID)
        {
            if (ID == 0 || ID == null)
            {
                return NotFound();
            }
            Category? category = _UnitOfWorkRepositra.Category.Get(c => c.ID == ID);
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? ID)
        {
            Category? category = _UnitOfWorkRepositra.Category.Get(c => c.ID == ID);
            if (category == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _UnitOfWorkRepositra.Category.Remove(category);
                _UnitOfWorkRepositra.Save();
                TempData["success"] = "Category Deleted successfully";
            }
            return RedirectToAction("Index");
        }
        public IActionResult BookPage()
        {
            return View();
        }
    }
}

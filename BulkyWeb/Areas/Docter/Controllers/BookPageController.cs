using BulkyBookDataAccess.Repositray;
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
        public IActionResult Create(BookingPagecs BookingPages)
        {
            _UnitOfWorkRepositra.BookingPages.Add(BookingPages);
            _UnitOfWorkRepositra.Save();
            TempData["success"] = "BookingPages Created successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? ID)
        {
            if (ID == 0 || ID == null)
            {
                return NotFound();
            }
            BookingPagecs? BookingPages = _UnitOfWorkRepositra.BookingPages.Get(c => c.Id == ID);
            return View(BookingPages);
        }
        [HttpPost]
        public IActionResult Edit(BookingPagecs BookingPages)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWorkRepositra.BookingPages.Update(BookingPages);
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
            BookingPagecs? BookingPages = _UnitOfWorkRepositra.BookingPages.Get(c => c.Id == ID);
            return View(BookingPages);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? ID)
        {
            BookingPagecs? BookingPages = _UnitOfWorkRepositra.BookingPages.Get(c => c.Id == ID);
            if (BookingPages == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _UnitOfWorkRepositra.BookingPages.Remove(BookingPages);
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

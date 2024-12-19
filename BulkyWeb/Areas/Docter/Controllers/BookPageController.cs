using BulkyBookDataAccess.Repositray.IRepositray;
using BulkyBookModels.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Areas.Docter.Controllers
{
    [Area("Docter")]
    public class BookPageController : Controller
    {
        private readonly IUnitOfWorkRepositray _UnitOfWorkRepositra;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookPageController(IUnitOfWorkRepositray UnitOfWorkRepositra, UserManager<ApplicationUser> userManager)
        {
            _UnitOfWorkRepositra = UnitOfWorkRepositra;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            List<BookingPagecs> objBookingPageList = _UnitOfWorkRepositra.BookingPages.GetAll().ToList();
            return View(objBookingPageList);
        }

        [HttpPost]
        public IActionResult BookPage(BookingPagecs BookingPages)
        {
            List<BookingPagecs> bookingPageData = _UnitOfWorkRepositra.BookingPages.GetAll().ToList();

            var Data = bookingPageData.Where(x => x.User_Email == BookingPages.User_Email).FirstOrDefault();

            if ((!(Data!.TypeUser == "Docter")) || Data == null)
            {
                _UnitOfWorkRepositra.BookingPages.Add(BookingPages);
            }
            else
            {
                if (Data.day != null)
                    Data.day = BookingPages.day;
                if (Data.day != null)
                    Data.date = BookingPages.date;
                if (Data.day != null)
                    Data.time = BookingPages.time;

                _UnitOfWorkRepositra.BookingPages.Update(Data);
                return View(Data);
            }

            _UnitOfWorkRepositra.Save();
            TempData["success"] = "BookingPages Created successfully";
            return View(BookingPages);
        }

        public async Task<IActionResult> BookPage(string Email)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            var users = await _userManager.Users
            .Select(u => new BookingPagecs
            {
                User_Email = u.Email ?? "Unknown",           // Provide default value for null Name
                User_Name = u.Name ?? "Unknown",         // Provide default value for null Majer
                IDNumber = u.IDNUMBER,         // Provide default value for null Majer
                TypeUser = u.TypeUser,
            }).ToListAsync();

            var user = users.Where(x => x.User_Email == userEmail).FirstOrDefault();
            
            if (Email != null)
            {
                List<BookingPagecs> bookings = _UnitOfWorkRepositra.BookingPages.GetAll().ToList();
                var DataBook = bookings.Where(x => x.User_Email == Email).FirstOrDefault();
                user!.day = DataBook!.day;
                user!.date = DataBook!.date;
                user!.User_Email = DataBook!.User_Email;
            }
            return View(user);
        }
    }
}
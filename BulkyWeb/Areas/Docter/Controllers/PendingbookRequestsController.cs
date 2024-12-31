using BulkyBookDataAccess.Repositray.IRepositray;
using BulkyBookModels.Model;
using BulkyBookUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Docter.Controllers
{
    [Area("Docter")]
    [Authorize(Roles =SD.Role_Docter)]
    public class PendingbookRequestsController : Controller
    {
        private readonly IUnitOfWorkRepositray _UnitOfWorkRepositra;
        private readonly IEmailService _EmailService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PendingbookRequestsController(IUnitOfWorkRepositray categoryRepositray ,
            IEmailService emailService, UserManager<ApplicationUser> userManager)
        {
            _UnitOfWorkRepositra = categoryRepositray;
            _EmailService = emailService;
            _userManager = userManager;
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
                
                var users = _userManager.Users
                        .Select(u => new ApplicationUser
                        {
                            Email = u.Email ?? "Unknown",
                            Name = u.Name ?? "Unknown",
                            IDNUMBER = u.IDNUMBER
                        }).ToList();
                
                var Obj = users.Where(x => x.IDNUMBER == category.IDNumber).FirstOrDefault();

                var BookData = new BookingPagecs
                {
                    User_Name = Obj.Name,
                    User_Email = Obj.Email,
                    Requst = category.Requst,
                };

                SentEmail(BookData);
                _UnitOfWorkRepositra.Save();
            }
            
            return PendingbookRequests();
        }

        [HttpGet("SentEmail")]
        public IActionResult SentEmail(BookingPagecs obj)
        {
            if (obj.Requst == true)
            {
                var message =
                new Messsage(new string[]
                { obj.User_Email }, "Your Company Registration is Approved",
                $"Dear [{obj.User_Name}],\r\n\r\nWe are pleased to inform you that your company registration has been approved. You can now log in and start using our services." +
                $"\r\n\r\n[http://localhost:5173/login]\r\n\r\n" +
                $"Thank you for choosing us.\r\nBest regards,\r\n[{obj.User_Name}]");

                _EmailService.SendEmail(message);
            }
            else
            {
                var message =
                new Messsage(new string[]
                { obj.User_Email }, "Your Booking Registration is Rejected",
                $"Dear [{obj.User_Name}],\r\n\r\nWe regret to inform you that your company registration request has been rejected. For more details, please contact our support team: [CareeerPathhub@gmail.com].\r\n\r\nBest regards,\r\n[{obj.User_Name}]");

                _EmailService.SendEmail(message);
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}

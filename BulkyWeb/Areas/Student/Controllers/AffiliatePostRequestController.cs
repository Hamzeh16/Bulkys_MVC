using BulkyBookDataAccess.Data;
using BulkyBookModels.Model;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    [Area("Student")]
    public class AffiliatePostRequestController : Controller
    {
        private readonly AppDbContext _db;
        public AffiliatePostRequestController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult SubmitPostRequest()
        {
            // This action will return the corresponding view for SubmitPostRequest
            return View();
        }

        // Action to handle the form submission
        [HttpPost]
        public IActionResult SubmitPostRequest(AffiliatePostRequest model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.IsApproved = false; // Not approved by default

                _db.AffiliatePostRequests.Add(model);
                _db.SaveChanges();

                return RedirectToAction("PostRequestSubmitted");
            }

            return View(model); // If validation fails, redisplay the form
        }

        // Action to confirm post submission
        public IActionResult PostRequestSubmitted()
        {
            return View();
        }
    }
}

using BulkyBookDataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext? _db;
        public AdminController(AppDbContext db)
        {
            _db = db;
        }
        // Display pending post requests
        public ActionResult PendingPostRequests()
        {
            var pendingRequests = _db?.AffiliatePostRequests.Where(r => !r.IsApproved).ToList();
            return View(pendingRequests);
        }

        // Approve a post request
        [HttpPost]
        public ActionResult ApprovePostRequest(int requestId)
        {
            var request = _db?.AffiliatePostRequests.Find(requestId);
            if (request != null)
            {
                request.IsApproved = true;
                request.ApprovedDate = DateTime.Now;
                _db?.SaveChanges();
            }

            return RedirectToAction("PendingPostRequests");
        }
    }
}

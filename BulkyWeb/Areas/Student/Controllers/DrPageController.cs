using BulkyBookModels.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Areas.Student.Controllers
{
    [Area("Student")]
    public class DrPageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DrPageController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> cis()
        {

            var users = await _userManager.Users
                    .Select(u => new ApplicationUser
                    {
                        Id = u.Id,
                        Name = u.Name ?? "Unknown",           // Provide default value for null Name
                        Majer = u.Majer ?? "Unknown",         // Provide default value for null Majer
                        Rank = u.Rank ?? "Unranked",          // Provide default value for null Rank
                        Office = u.Office ?? "Not Assigned",  // Provide default value for null Office
                        ImageUrl = u.ImageUrl ?? "/images/default.png" // Provide default image URL for null ImageUrl
                    }).ToListAsync();

            return View(users);
        }
    }
}

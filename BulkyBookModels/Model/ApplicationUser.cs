using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookModels.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "ID NUMBER")]
        public int IDNUMBER { get; set; }
    }
}

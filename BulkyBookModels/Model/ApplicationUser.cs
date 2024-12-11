using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookModels.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }

        [Required]
        [Display(Name = "ID NUMBER")]
        [Range(1,int.MaxValue)]
        public int IDNUMBER { get; set; }

        public string? Rank { get; set; }

        public string? Office { get; set; }

        public string? Majer { get; set; }

        public string? ImageUrl { get; set; }
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookModels.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Category Name")]
        public string NAME { get; set; }
        [Range(1, 100,ErrorMessage ="The Number Between 1 to 100")]
        [DisplayName("Display Order")]
        public int DISPLAYORDER { get; set; }
    }
}

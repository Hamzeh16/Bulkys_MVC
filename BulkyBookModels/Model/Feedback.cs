using System.ComponentModel.DataAnnotations;

namespace BulkyBookModels.Model
{
    public class Feedback
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500)]
        public string? Comment { get; set; }

        [MaxLength(50)]
        public string? email { get; set; }
    }
}
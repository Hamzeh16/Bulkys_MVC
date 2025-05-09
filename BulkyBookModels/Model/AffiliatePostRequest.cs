using System.ComponentModel.DataAnnotations;

namespace BulkyBookModels.Model
{
    public class AffiliatePostRequest
    {
        [Key]
        public int RequestId { get; set; }

        public int AffiliateId { get; set; }

        //[Required(ErrorMessage = "Post title is required")]
        //[StringLength(250, ErrorMessage = "Post title cannot exceed 250 characters")]
        public string PostTitle { get; set; }

        //[Required(ErrorMessage = "Post content is required")]
        public string PostContent { get; set; }

        public bool IsApproved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ApprovedDate { get; set; }
    }

}

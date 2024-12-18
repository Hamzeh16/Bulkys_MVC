using System.ComponentModel.DataAnnotations;

namespace BulkyBookModels.Model
{
    public class BookingPagecs
    {
        [Key]
        public int ID { get; set; }
        public string? day { get; set; }
        public string? time { get; set; }
        public DateTime? date{ get; set; }
        public string? TypeUser { get; set; }
        public string? User_Email  { get; set; }
        public string? User_Name  { get; set; }
        public int? IDNumber  { get; set; }
        public bool? Requst {  get; set; }
    }
}
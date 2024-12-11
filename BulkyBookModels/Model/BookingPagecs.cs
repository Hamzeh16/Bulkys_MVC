using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookModels.Model
{
    public class BookingPagecs
    {
        [Key]
        public int Id { get; set; }
        public string? day { get; set; }
        public string? time { get; set; }   
        public DateTime? date{ get; set; }  

    }
}

using BulkyBookModels.Model;
using BulkyBookModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookDataAccess.Repositray.IRepositray
{
    public interface IBookingPage : IRepositray<BookingPagecs>
    {
        void Update(BookingPagecs BookingPagecsObj);
    }
  
}

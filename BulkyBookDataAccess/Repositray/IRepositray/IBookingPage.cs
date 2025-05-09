using BulkyBookModels.Model;

namespace BulkyBookDataAccess.Repositray.IRepositray
{
    public interface IBookingPage : IRepositray<BookingPagecs>
    {
        void Update(BookingPagecs BookingPagecsObj);
    }
}
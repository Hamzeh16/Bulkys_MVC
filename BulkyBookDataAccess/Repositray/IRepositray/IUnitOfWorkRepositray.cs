namespace BulkyBookDataAccess.Repositray.IRepositray
{
    public interface IUnitOfWorkRepositray
    {
        ICategoryRepositray Category { get; }
        IProductRepositray Product { get; set; }
        IBookingPage BookingPages { get; set; }
        FeedbackInterface Feedback { get; set; }

        void Save();
    }
}

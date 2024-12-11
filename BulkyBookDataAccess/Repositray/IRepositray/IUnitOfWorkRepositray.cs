namespace BulkyBookDataAccess.Repositray.IRepositray
{
    public interface IUnitOfWorkRepositray
    {
        ICategoryRepositray Category { get; }
        IProductRepositray Product { get; set; }
        IBookingPage bookingPage { get; set; }
       
        void Save();
    }
}

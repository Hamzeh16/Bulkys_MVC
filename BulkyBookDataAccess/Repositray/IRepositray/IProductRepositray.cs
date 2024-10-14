using BulkyBookModels.Model;

namespace BulkyBookDataAccess.Repositray.IRepositray
{
    public interface IProductRepositray : IRepositray<Product>
    {
        void Update(Product ProductObj);
    }
}

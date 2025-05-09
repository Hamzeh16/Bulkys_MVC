using BulkyBookDataAccess.Data;
using BulkyBookDataAccess.Repositray.IRepositray;
using BulkyBookModels.Model;

namespace BulkyBookDataAccess.Repositray
{
    public class ProductRepositray : Repository<Product>, IProductRepositray
    {
        private AppDbContext _db;
        public ProductRepositray(AppDbContext db) : base(db) 
        {
            _db = db;
        }
        public void Update(Product ProductObj)
        {
            _db.Products.Update(ProductObj);
        }
    }
}

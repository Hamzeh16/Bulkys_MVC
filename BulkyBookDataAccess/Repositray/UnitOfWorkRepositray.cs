using BulkyBookDataAccess.Data;
using BulkyBookDataAccess.Repositray.IRepositray;

namespace BulkyBookDataAccess.Repositray
{
    public class UnitOfWorkRepositray : IUnitOfWorkRepositray
    {
        public ICategoryRepositray Category {  get; set; }
        public IProductRepositray Product {  get; set; }

        private AppDbContext _db;
        public UnitOfWorkRepositray(AppDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepositray(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

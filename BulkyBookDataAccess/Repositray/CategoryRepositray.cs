using BulkyBookDataAccess.Data;
using BulkyBookDataAccess.Repositray.IRepositray;
using BulkyBookModels.Models;

namespace BulkyBookDataAccess.Repositray
{
    public class CategoryRepository : Repository<Category>, ICategoryRepositray
    {
        private AppDbContext _db;
        public CategoryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}


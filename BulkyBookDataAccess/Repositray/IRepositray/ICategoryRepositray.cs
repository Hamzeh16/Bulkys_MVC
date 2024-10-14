using BulkyBookModels.Models;

namespace BulkyBookDataAccess.Repositray.IRepositray
{
    public interface ICategoryRepositray : IRepositray<Category>
    {
        void Update(Category CategoryObj);
    }
}

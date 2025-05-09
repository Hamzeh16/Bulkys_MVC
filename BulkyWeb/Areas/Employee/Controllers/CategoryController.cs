using BulkyBookDataAccess.Repositray.IRepositray;
using BulkyBookModels.Models;
using BulkyBookUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWorkRepositray _UnitOfWorkRepositra;
        public CategoryController(IUnitOfWorkRepositray categoryRepositray)
        {
            _UnitOfWorkRepositra = categoryRepositray;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _UnitOfWorkRepositra.Category.GetAll().ToList();
            objCategoryList = objCategoryList.Where(x => x.IsAdded == true && x.IsApproved == true).ToList();
            return View(objCategoryList);
        }
    }
}

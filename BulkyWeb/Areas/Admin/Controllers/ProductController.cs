using BulkyBookDataAccess.Repositray.IRepositray;
using BulkyBookModels.Model;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWorkRepositray _UnitOfWorkRepositra;
        public ProductController(IUnitOfWorkRepositray categoryRepositray)
        {
            _UnitOfWorkRepositra = categoryRepositray;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Product> objProductList = _UnitOfWorkRepositra.Product.GetAll().ToList();
            return View(objProductList);
        }
    }
}

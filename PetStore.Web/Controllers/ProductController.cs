using Microsoft.AspNetCore.Mvc;
using PetStore.Services.Interfaces;

namespace PetStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var result = this._productService.ListAllProducts();

            return View(result);
        }
    }
}
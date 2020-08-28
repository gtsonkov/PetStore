using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetStore.Services.Interfaces;
using PetStore.Services.Models.Product.InputModels;

namespace PetStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult All()
        {
            var result = this._productService.GetAll();

            return View(result);
        }

        [HttpGet]
        //[Authorize("Admin")]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(AddProductServiceModel model)
        {
            this._productService.AddProduct(model);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            this._productService.RemoveById(id);

            return RedirectToAction("Index");
        }

        public IActionResult Details(string id)
        {
            var currModel = this._productService.GetById(id);

            return View(currModel);
        }

        public IActionResult Edit(string id)
        {
            var currModel = this._productService.GetById(id);

            return View(currModel);
        }

        [HttpPost]
        public IActionResult Edit(EditProductServiceModel model)
        {
            this._productService.EditProduct(model.Id, model);

            return RedirectToAction("Index");
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetStore.Common;
using PetStore.Services.Interfaces;
using PetStore.Services.Models.Product.InputModels;
using PetStore.Services.Models.Product.OutputModels;
using System;
using System.Collections.Generic;

namespace PetStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
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

        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return RedirectToAction("All");
            }

            var result = this._productService.SearchByName(searchString, false);

            var models = this._mapper.Map<List<ListAllProductsServiceModel>>(result);

            return View("All",models);
        }
    }
}
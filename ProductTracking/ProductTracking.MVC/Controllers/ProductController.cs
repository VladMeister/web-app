using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.BL.DTO;
using ProductTracking.BL.Services.Interfaces;
using ProductTracking.MVC.Models;

namespace ProductTracking.MVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _mapper
               .Map<IEnumerable<ProductDto>, IEnumerable<ProductViewModel>>(_productService.GetAllProducts());

            return View(products);
        }

        [HttpPost]
        public IActionResult ProductSearch(string searchString)
        {
            var products = _mapper
               .Map<IEnumerable<ProductDto>, IEnumerable<ProductViewModel>>(_productService.GetProductsByName(searchString));

            return PartialView(products);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productDto = _mapper.Map<ProductViewModel, ProductDto>(product);

                var result = _productService.AddProduct(productDto);

                if (result)
                {
                    TempData["message"] = $"Product {product.Name} was added.";

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", $"No company or realization place with such name were found.");
                }
            }

            return View(product);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var product = _mapper.Map<ProductDto, ProductEditViewModel>(_productService.GetProductById(id));

                if (product != null)
                {
                    return View(product);
                }
            }

            ModelState.AddModelError("", $"No such product was found.");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductEditViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productDto = _mapper.Map<ProductEditViewModel, ProductDto>(product);

                _productService.UpdateProduct(productDto);
                TempData["message"] = $"Product {product.Name} info was updated.";

                return RedirectToAction("Index", "Home");
            }

            return View(product);
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var product = _productService.GetProductById(id);

                if (product != null)
                {
                    _productService.DeleteProduct(product);
                    if (User.IsInRole("admin"))
                    {
                        TempData["message"] = $"Product {product.Name} was deleted.";
                    }
                    else
                    {
                        TempData["message"] = $"Product {product.Name} was successfully sold.";
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", $"No such employee was found.");
            return View();
        }
    }
}
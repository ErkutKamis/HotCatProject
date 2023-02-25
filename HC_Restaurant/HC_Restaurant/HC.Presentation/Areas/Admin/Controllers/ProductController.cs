using FluentValidation.Results;
using Hc.Application.Models.DTO;
using Hc.Application.Service.Interface;
using HC.Application.Service.Interface;
using HC.Application.Validation.FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace HC.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetProducts());
        }

        #region CreateProduct
        public async Task<IActionResult> AddProduct()
        {
            ViewBag.Categories = await _categoryService.GetDefaultCategories();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDTO model)
        {
            ViewBag.Categories = await _categoryService.GetDefaultCategories();
            CreateProductDTOValidation validator = new CreateProductDTOValidation();
            ValidationResult results = validator.Validate(model);
            if (results.IsValid)
            {
                var result = await _productService.Create(model);
                TempData["message"] = result;
                if (result == "Product added!")
                {
                    return RedirectToAction("index");
                }
                return View(model);
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    TempData["message"] += "Error message: " + item.ErrorMessage + "\n";
                }
                return View(model);
            }
        }
        #endregion

        #region UpdateProduct
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            var product = await _productService.GetById(id);
            ViewBag.Categories = await _categoryService.GetDefaultCategories();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO model)
        {
            ViewBag.Categories = await _categoryService.GetDefaultCategories();
            UpdateProductDTOValidation validator = new UpdateProductDTOValidation();
            ValidationResult results = validator.Validate(model);
            if (results.IsValid)
            {
                TempData["message"] = await _productService.Update(model);
                return RedirectToAction("index");
            }
            foreach (var item in results.Errors)
            {
                TempData["message"] = "Error message: " + item.ErrorMessage + "\n";
            }
            return View(model);
        }
        #endregion

        #region DeleteProduct
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            TempData["message"] = await _productService.Delete(id);
            return RedirectToAction("index");
        }
        #endregion
    }
}

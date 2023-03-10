using FluentValidation.Results;
using Hc.Application.Models.DTO;
using Hc.Application.Service.Interface;
using HC.Application.Validation.FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HC.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetCategories());
        }
        #region CreateCategory
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryDTO model)
        {
            CreateCategoryDTOValidation validator = new CreateCategoryDTOValidation();
            ValidationResult results = validator.Validate(model);
            if (results.IsValid)
            {
                var result = await _categoryService.Create(model);
                TempData["message"] = result;
                if (result == "Category added!")
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

        #region UpdateCategory
        public async Task<IActionResult> UpdateCategory(Guid id)
        {
            var category = await _categoryService.GetById(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO model)
        {
            UpdateCategoryDTOValidation validator = new UpdateCategoryDTOValidation();
            ValidationResult results = validator.Validate(model);
            if (results.IsValid)
            {
                TempData["message"] = await _categoryService.Update(model);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                TempData["message"] = "Error message: " + item.ErrorMessage + "\n";
            }
            return View(model);
        }
        #endregion

        #region DeleteCategory
        
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            TempData["message"] = await _categoryService.Delete(id);
            return RedirectToAction("index");
        }




        #endregion
    }
}

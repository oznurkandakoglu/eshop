﻿using eshop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public MenuViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        { 
            var categories = _categoryService.GetCategories();

            return View(categories);
        }
    }
}

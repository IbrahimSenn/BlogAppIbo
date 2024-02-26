using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class TagsMenu: ViewComponent
    {
        private ICategoryRepository _categoryRepository;
        public TagsMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _categoryRepository.Categories.ToListAsync());
        }
    }
}
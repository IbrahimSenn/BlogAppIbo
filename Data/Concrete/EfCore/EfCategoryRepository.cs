using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private BlogContext _context;
        public EfCategoryRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<Category> Categories => _context.Categories;

        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
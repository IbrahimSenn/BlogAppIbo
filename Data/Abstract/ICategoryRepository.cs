using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface ICategoryRepository

    {
        IQueryable<Category> Categories { get; }
        void CreateCategory(Category category);
    }
}
using Api.W.Movies.DAL;
using Api.W.Movies.DAL.Models;
using Api.W.Movies.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Api.W.Movies.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CategoryExistsByIdAsync(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            return await _context.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Name == name);
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            category.CreatedDate = DateTime.UtcNow;
            await _context.Categories.AddAsync(category);
            return await SaveAsync();
            //SQL_INSERT
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryAsync(id); // Primero consulto que si exista la categoria

            if (category == null)
            {
                return false; // La categoria no existe
            }

            _context.Categories.Remove(category);
            return await SaveAsync();
            // SQL DELETE FROM CATEGORIES WHERE Id = id
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id) // async y await, metodos asincronicos necesitan esto
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id); //lambda functions or expressions
            //select *from categories where Id = id
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            category.ModifiedDate = DateTime.UtcNow;
            _context.Categories.Update(category);
            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
            //SQL_INSERT
        }
    }
}

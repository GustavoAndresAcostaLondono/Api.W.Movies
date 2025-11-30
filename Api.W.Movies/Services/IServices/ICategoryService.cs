using Api.W.Movies.DAL.Models;
using Api.W.Movies.DAL.Models.Dtos;

namespace Api.W.Movies.Services.IServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryAsync(int id);
        Task<bool> CategoryExistsByIdAsync(int id);
        Task<bool> CategoryExistsByNameAsync(string name);
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryDto);
        Task<CategoryDto> UpdateCategoryAsync(int id, Category categoryDto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}

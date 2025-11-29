using Api.W.Movies.DAL.Models;

namespace Api.W.Movies.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync(); //Retorna una lista de categorias
        Task<Category> GetCategoryAsync(int id); // Retorna una categoria por ID
        Task<bool> CategoryExistsByIdAsync (int id); // Dice si existe una categoria por ID
        Task<bool> CategoryExistsByNameAsync (string name); // Dice si existe una categoria por Nombre
        Task<bool> CreateCategoryAsync (Category category); //Crea una categoria
        Task<bool> UpdateCategoryAsync(Category category); //Puedo actualizar el nombre y la fecha de actualización
        Task<bool> DeleteCategoryAsync (int id); // Elimina una categoria
    }
}

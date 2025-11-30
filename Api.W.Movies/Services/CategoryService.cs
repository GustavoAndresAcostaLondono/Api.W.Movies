using Api.W.Movies.DAL.Models;
using Api.W.Movies.DAL.Models.Dtos;
using Api.W.Movies.Repository.IRepository;
using Api.W.Movies.Services.IServices;
using AutoMapper;

namespace Api.W.Movies.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> CategoryExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
        {
            //Validar si la categoria ya existe
            var categoryExists = await _categoryRepository.CategoryExistsByNameAsync(categoryCreateDto.Name);

            if (categoryExists)
            {
                throw new InvalidOperationException($"Ya existe una categoría con el nombre de '{categoryCreateDto.Name}'");
            }

            //Mapear el DTO a la entidad
            var category = _mapper.Map<Category>(categoryCreateDto);

            //Crear la categoria en el repositorio
            var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated)
            {
                throw new Exception("Ocurrio un error al crear la categoría.");
            }

            //Mapear la entidad creada al DTO
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            //Obtener las categorias del repositorio
            var categories = await _categoryRepository.GetCategoriesAsync(); // Solo estoy llamando el metodo desde la capa Repository

            //Mapear toda la colección de una vez
            return _mapper.Map<ICollection<CategoryDto>>(categories); //Mapeo la lista de categorias a una lista de categorias Dto
        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            //Obtener la categoria del repositorio
            var category = await _categoryRepository.GetCategoryAsync(id);

            //Mapear el objeto de una vez
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> UpdateCategoryAsync(int id, Category categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}

using Api.W.Movies.DAL.Models;
using Api.W.Movies.DAL.Models.Dtos;
using Api.W.Movies.Repository;
using Api.W.Movies.Repository.IRepository;
using Api.W.Movies.Services.IServices;
using AutoMapper;

namespace Api.W.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<bool> MovieExistsByIdAsync(int id)
        {
            return await _movieRepository.MovieExistsByIdAsync(id);
        }

        public async Task<bool> MovieExistsByNameAsync(string name)
        {
            return await _movieRepository.MovieExistsByNameAsync(name);
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieCreateDto)
        {
            var movieExists = await _movieRepository.MovieExistsByNameAsync(movieCreateDto.Name);

            if (movieExists)
            {
                throw new InvalidOperationException($"Ya existe una película con el nombre '{movieCreateDto.Name}'");
            }

            var movie = _mapper.Map<Movie>(movieCreateDto);

            var movieCreated = await _movieRepository.CreateMovieAsync(movie);

            if (!movieCreated)
            {
                throw new Exception("Ocurrió un error al crear la película.");
            }

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movieExists = await _movieRepository.GetMovieAsync(id);

            if (movieExists == null)
            {
                throw new InvalidOperationException($"No se encontró la película con ID: '{id}'");
            }

            var movieDeleted = await _movieRepository.DeleteMovieAsync(id);

            if (!movieDeleted)
            {
                throw new Exception("Ocurrió un error al eliminar la película.");
            }

            return movieDeleted;
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();

            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);

            if (movie == null)
            {
                throw new InvalidOperationException($"No se encontró la película con ID: '{id}'");
            }
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id)
        {
            //Validar si la película ya existe
            var movieExists = await _movieRepository.GetMovieAsync(id);

            if (movieExists == null)
            {
                throw new InvalidOperationException($"No se encontró la película con ID: '{id}'");
            }

            //Verificar si el nuevo nombre de la película ya existe
            var nameExists = await _movieRepository.MovieExistsByNameExcludingIdAsync(dto.Name, id);

            if (nameExists)
            {
                throw new InvalidOperationException($"Ya existe otra película con el nombre de '{dto.Name}'");
            }

            //Validar que si se realicen cambios cambios
            if (movieExists.Name == dto.Name &&
                movieExists.Duration == dto.Duration &&
                movieExists.Description == dto.Description &&
                movieExists.Clasification == dto.Clasification)
            {
                throw new InvalidOperationException("No se detectaron cambios en la película. Debe modificar al menos un campo.");
            }

            //Mapear el DTO a la entidad
            _mapper.Map(dto, movieExists);

            //Actualizamos la película en el repositorio
            var movieUpdated = await _movieRepository.UpdateMovieAsync(movieExists);

            if (!movieUpdated)
            {
                throw new Exception("Ocurrio un error al actualizar la película.");
            }

            //Retornar el Dto actualizado
            return _mapper.Map<MovieDto>(movieExists);
        }
    }
}

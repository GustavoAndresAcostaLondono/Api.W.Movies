using Api.W.Movies.DAL.Models.Dtos;

namespace Api.W.Movies.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync();
        Task<MovieDto> GetMovieAsync(int id);
        Task<bool> MovieExistsByIdAsync(int id);
        Task<bool> MovieExistsByNameAsync(string name);
        Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieDto);
        Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id);
        Task<bool> DeleteMovieAsync(int id);
    }
}

using P_Review.ApiMovie.DTOs.MovieDTOs;

namespace P_Review.ApiMovie.Services;

public interface IMovieService
{
    Task<IEnumerable<MovieDTO>> GetMovies();
    Task<MovieDTO> GetMoviesById(int id);
    Task AddMovies(MovieDTO movieDto);
    Task UpdateMovie(MovieDTO movieDto);
    Task RemoveMovie(int id);
}

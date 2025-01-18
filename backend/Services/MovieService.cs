using AutoMapper;
using P_Review.ApiMovie.DTOs;
using P_Review.ApiMovie.Models;
using P_Review.ApiMovie.Repositories;

namespace P_Review.ApiMovie.Services;

public class MovieService : IMovieService
{
    private readonly IMapper _mapper;
    private IMovieRepository _MovieRepository;

    public MovieService(IMapper mapper, IMovieRepository MovieRepository)
    {
        _mapper = mapper;
        _MovieRepository = MovieRepository;
    }

    public async Task<IEnumerable<MovieDTO>> GetMovies()
    {
        var MoviesEntity = await _MovieRepository.GetAll();
        return _mapper.Map<IEnumerable<MovieDTO>>(MoviesEntity);
    }

    public async Task<MovieDTO> GetMoviesById(int id)
    {
        var MovieEntity = await _MovieRepository.GetById(id);
        return _mapper.Map<MovieDTO>(MovieEntity);
    }
    public async Task AddMovies(MovieDTO MovieDto)
    {
        var MovieEntity = _mapper.Map<Movie>(MovieDto);
        await _MovieRepository.Create(MovieEntity);
        MovieDto.Id = MovieEntity.Id;
    }

    public async Task UpdateMovie(MovieDTO MovieDto)
    {
        var userEntity = _mapper.Map<Movie>(MovieDto);
        await _MovieRepository.Update(userEntity);
    }

    public async Task RemoveMovie(int id)
    {
        var MovieEntity = await _MovieRepository.GetById(id);
        await _MovieRepository.Delete(MovieEntity.Id);
    }
}

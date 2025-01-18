using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P_Review.ApiMovie.DTOs.MovieDTOs;
using P_Review.ApiMovie.Services;
using System.Data;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> Get()
        {
            var moviesDto = await _movieService.GetMovies();
            if (moviesDto == null)
            {
                return NotFound("Movies not found");
            }
            return Ok(moviesDto);
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public async Task<ActionResult<MovieDTO>> Get(int id)
        {
            var movieDto = await _movieService.GetMoviesById(id);
            if (movieDto == null)
            {
                return NotFound("Movie not found");
            }
            return Ok(movieDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MovieDTO movieDto)
        {
            if (movieDto == null)
                return BadRequest("Data Invalid");

            await _movieService.AddMovies(movieDto);

            return new CreatedAtRouteResult("GetMovie",
                new { id = movieDto.Id }, movieDto);
        }

        [HttpPut]
        public async Task<ActionResult<MovieDTO>> Put([FromBody] MovieDTO movieDto)
        {
            if (movieDto == null)
                return BadRequest("Data invalid");

            await _movieService.UpdateMovie(movieDto);

            return Ok(movieDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieDTO>> Delete(int id)
        {
            var movieDto = await _movieService.GetMoviesById(id);

            if (movieDto == null)
            {
                return NotFound("Movie not found");
            }

            await _movieService.RemoveMovie(id);

            return Ok(movieDto);
        }
    }
}

 
using P_Review.ApiMovie.Context;
using Microsoft.EntityFrameworkCore;
using P_Review.ApiMovie.Models;

namespace P_Review.ApiMovie.Repositories;
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            var Movies = await _context.Movies.Include(c => c.User).ToListAsync();
            return Movies;
        }

        public async Task<Movie> GetById(int id)
        {
            return await _context.Movies.Include(c => c.User).Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Movie> Create(Movie Movie)
        {
            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();
            return Movie;
        }

        public async Task<Movie> Update(Movie Movie)
        {
            _context.Entry(Movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Movie;
        }

        public async Task<Movie> Delete(int id)
        {
            var Movie = await GetById(id);
            _context.Movies.Remove(Movie);
            await _context.SaveChangesAsync();
            return Movie;
        }
    }

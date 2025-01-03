using P_Review.ApiMovie.Models;

namespace P_Review.ApiMovie.Repositories;
        public interface IMovieRepository
        {
            Task<IEnumerable<Movie>> GetAll();
            Task<Movie> GetById(int id);
            Task<Movie> Create(Movie movie);
            Task<Movie> Update(Movie movie);
            Task<Movie> Delete(int id);
        }


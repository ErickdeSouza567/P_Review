using P_Review.ApiMovie.Models;


namespace P_Review.ApiMovie.Repositories;
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<IEnumerable<User>> GetUsersProducts();
        Task<User> GetById(int id);
        Task<User> Create(User User);
        Task<User> Update(User User);
        Task<User> Delete(int id);
    }
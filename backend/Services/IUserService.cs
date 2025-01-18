using P_Review.ApiMovie.DTOs.UserDTOs;

namespace P_Review.ApiMovie.Services;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetUsers();
    Task<IEnumerable<UserMoviesDTO>> GetUserMovies();
    Task<UserDTO> GetUserById(int id);
    Task AddUser(UserDTO userDto);
    Task UpdateUser(UserDTO userDto);
    Task RemoveUser(int id);

}

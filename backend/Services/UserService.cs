using AutoMapper;
using P_Review.ApiMovie.DTOs.UserDTOs;
using P_Review.ApiMovie.Models;
using P_Review.ApiMovie.Repositories;

namespace P_Review.ApiMovie.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var usersEntity = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDTO>>(usersEntity);
        }

        public async Task<IEnumerable<UserMoviesDTO>> GetUserMovies()
        {
            var usersEntity = await _userRepository.GetUsersMovies();
            return _mapper.Map<IEnumerable<UserMoviesDTO>>(usersEntity);
        }


        public async Task<UserDTO> GetUserById(int id)
        {
            var userEntity = await _userRepository.GetById(id);
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task AddUser(UserDTO userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            await _userRepository.Create(userEntity);
            userDto.UserId = userEntity.UserId;
        }

        public async Task UpdateUser(UserDTO userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            await _userRepository.Update(userEntity);
        }

        public async Task RemoveUser(int id)
        {
            var userEntity = _userRepository.GetById(id).Result;
            await _userRepository.Delete(userEntity.UserId);
        }
    }
}

using AutoMapper;
using P_Review.ApiMovie.DTOs.MovieDTOs;
using P_Review.ApiMovie.DTOs.UserDTOs;
using P_Review.ApiMovie.Models;

namespace P_Review.ApiMovie.DTOs.Mapings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserMoviesDTO>().ReverseMap();
            CreateMap<MovieDTO, Movie>();
            CreateMap<Movie, MovieDTO>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
        }
    }
}

using P_Review.ApiMovie.Models;
using System.ComponentModel.DataAnnotations;

namespace P_Review.ApiMovie.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        public ICollection<Movie>? Movies { get; set; }
    }
}

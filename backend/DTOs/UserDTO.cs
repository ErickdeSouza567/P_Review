using P_Review.ApiMovie.Models;
using System.ComponentModel.DataAnnotations;

namespace P_Review.ApiMovie.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "The First Name is required")]
        [MinLength(2)]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name is required")]
        [MinLength(2)]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "The Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "The Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }
    }
}

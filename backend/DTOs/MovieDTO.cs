using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;
using P_Review.ApiMovie.Models;

namespace P_Review.ApiMovie.DTOs;

public class MovieDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The Description is Required")]
    [MinLength(5)]
    [MaxLength(200)]
    public string? Description { get; set; }

    [MaxLength(250)]
    [DisplayName("Product Image")]
    public string? ImageURL { get; set; }

    public string? UserName { get; set; }

    public int UserID { get; set; }
    [JsonIgnore]
    public User? User { get; set; }
}

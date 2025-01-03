namespace P_Review.ApiMovie.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageURL { get; set; }
    public User? User { get; set; }
    public int UserId { get; set; }
}

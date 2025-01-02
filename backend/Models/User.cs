namespace P_Review.Models;

public class User
{
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }

    public int Age { get; set; }

    public ICollection<Movie>? Movies { get; set; }
}

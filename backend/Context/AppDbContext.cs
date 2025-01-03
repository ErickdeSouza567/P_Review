using P_Review.ApiMovie.Models;
using Microsoft.EntityFrameworkCore;

namespace P_Review.ApiMovie.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User>? Users { get; set; }  // Corrigido para plural 'Users'
    public DbSet<Movie>? Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // Configurações para User
        mb.Entity<User>().HasKey(u => u.UserId);  // Definindo chave primária

        mb.Entity<User>()
            .Property(u => u.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        mb.Entity<User>()
            .Property(u => u.LastName)
            .HasMaxLength(100)
            .IsRequired();

        mb.Entity<User>()
            .Property(u => u.Email)
            .HasMaxLength(255)
            .IsRequired();

        mb.Entity<User>()
            .Property(u => u.DateOfBirth)
            .IsRequired();  // Tornando obrigatório o campo DateOfBirth

        mb.Entity<User>()
            .Property(u => u.Age)
            .HasDefaultValue(0);  // Definindo valor padrão para 'Age'

        // Configurações para Movie
        mb.Entity<Movie>().HasKey(m => m.Id);  // Definindo chave primária

        mb.Entity<Movie>()
            .Property(m => m.Name)
            .HasMaxLength(200)
            .IsRequired();

        mb.Entity<Movie>()
            .Property(m => m.Description)
            .HasMaxLength(500)
            .IsRequired(false);  // O campo Description é opcional

        mb.Entity<Movie>()
            .Property(m => m.ImageURL)
            .HasMaxLength(255)
            .IsRequired(false);  // O campo ImageURL é opcional

        // Relacionamento entre User e Movie
        mb.Entity<Movie>()
            .HasOne(m => m.User)   // Relacionando Movie a User
            .WithMany(u => u.Movies)
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Cascade);  // Cascata na exclusão de User

        // Dados de inicialização para User e Movie (se necessário)
        mb.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                DateOfBirth = new DateTime(1990, 1, 1),  // Exemplo de data
                Age = 31  // Age calculado conforme a lógica definida
            }
        );

        mb.Entity<Movie>().HasData(
            new Movie
            {
                Id = 1,
                Name = "Example Movie",
                Description = "An example movie description.",
                ImageURL = "https://www.sonypictures.com.br/sites/brazil/files/2022-03/DP_4690515_TC_1400x2100_DP_4690517_SpidermanFarFromHome_2019_ITUNES_2000x3000_BR_thumbnail_xlarge.jpg",
                UserId = 1  // Relacionado ao User com UserId = 1
            }
        );
    }
}

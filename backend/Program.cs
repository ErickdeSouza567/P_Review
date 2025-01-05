using Microsoft.EntityFrameworkCore;
using P_Review.ApiMovie.Context;
using P_Review.ApiMovie.Repositories;
using P_Review.ApiMovie.Services;
using LojaMicro.ApiProduto.Repositories;  // Use o namespace correto para o seu AppDbContext

namespace P_Review.ApiMovie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)
                    ));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

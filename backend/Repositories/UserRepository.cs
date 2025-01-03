using P_Review.ApiMovie.Context;
using Microsoft.EntityFrameworkCore;
using P_Review.ApiMovie.Models;
using P_Review.ApiMovie.Repositories;

namespace LojaMicro.ApiProduto.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersProducts()
        {
            return await _context.Users.Include(x => x.Movies).ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Where(p => p.UserId == id).FirstOrDefaultAsync();
        }

        public async Task<User> Create(User User)
        {
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            return User;
        }

        public async Task<User> Update(User User)
        {
            _context.Entry(User).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return User;
        }

        public async Task<User> Delete(int id)
        {
            var product = await GetById(id);
            _context.Users.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
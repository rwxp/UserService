using Core.Models;
using Core.Ports.Out.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Adapter.PostgreSQL
{
    public class PostgreUserStore : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public PostgreUserStore(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUser(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User?> FindUserByEmail(string email)
        {
            return await _context.users.FirstOrDefaultAsync(u => u.email == email);
        }
    }
};



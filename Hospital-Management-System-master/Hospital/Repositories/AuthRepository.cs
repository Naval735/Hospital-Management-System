using Hospital.DAL;
using Hospital.Interfaces;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly PatientDal _context;

        public AuthRepository(PatientDal context)
        {
            _context = context;
        }

        public async Task<User> RegisterAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
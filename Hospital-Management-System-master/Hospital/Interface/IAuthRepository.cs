using Hospital.Models;
using System.Threading.Tasks;

namespace Hospital.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(User user);

        Task<User> GetByEmailAsync(string email);
    }
}
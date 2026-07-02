using Hospital.DTOs;
using Hospital.Models;
using System.Threading.Tasks;

namespace Hospital.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(RegisterDto dto);

        Task<AuthResponseDto> LoginAsync(LoginDto dto);
    }
}
using Hospital.Models;

namespace Hospital.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
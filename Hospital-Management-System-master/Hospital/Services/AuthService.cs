using Hospital.DTOs;
using Hospital.Interfaces;
using Hospital.Models;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;

        public AuthService(
     IAuthRepository authRepository,
     IJwtService jwtService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        public async Task<User> RegisterAsync(RegisterDto dto)
        {
            // Check if email already exists
            var existingUser = await _authRepository.GetByEmailAsync(dto.Email);

            if (existingUser != null)
                throw new System.Exception("Email already exists.");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "Patient",
                IsActive = true
            };

            return await _authRepository.RegisterAsync(user);
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _authRepository.GetByEmailAsync(dto.Email);

            if (user == null)
                throw new Exception("Invalid Email.");

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new Exception("Invalid Password.");

            var token = _jwtService.GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
                Email = user.Email,
                Role = user.Role,
                Expiration = DateTime.UtcNow.AddMinutes(60)
            };
        }
    }
}
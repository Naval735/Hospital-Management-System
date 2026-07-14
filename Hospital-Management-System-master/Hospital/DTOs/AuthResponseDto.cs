using System;

namespace Hospital.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public DateTime Expiration { get; set; }
    }
}
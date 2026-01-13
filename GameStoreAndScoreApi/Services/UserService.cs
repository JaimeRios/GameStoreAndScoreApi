using GameStoreAndScoreApi.DTOs;
using GameStoreAndScoreApi.Models;
using GameStoreAndScoreApi.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace GameStoreAndScoreApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> CreateAsync(CreateUserDto dto)
        {
            var existingUser = await _repository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new Exception("User already exists");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = HashPassword(dto.Password),
                CreatedAt = DateTime.UtcNow
            };

            return await _repository.CreateAsync(user);
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public int Create(CreateUserDto userDto)
        {
            return 0;
        }

        public string GetById(int id)
        {
            return string.Empty;
        }
    }
}

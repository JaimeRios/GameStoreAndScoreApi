using GameStoreAndScoreApi.Application.DTOs;
using GameStoreAndScoreApi.Domain.Entities;
using GameStoreAndScoreApi.Domain.Exceptions;
using GameStoreAndScoreApi.Infrastructure.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace GameStoreAndScoreApi.Application.Services
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
                throw new UserAlreadyExistsException(dto.Email);

            var now = DateTime.UtcNow;

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email.Trim().ToLowerInvariant(),

                PasswordHash = HashPassword(dto.Password),
                PasswordUpdatedAt = now,

                IsActive = true,
                CreatedAt = now
            };

            return await _repository.CreateAsync(user);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public async Task<bool> UpdateAsync(int id, UpdateUserDto dto)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
                return false;

            if (!string.IsNullOrWhiteSpace(dto.Name))
                user.Name = dto.Name;

            if (!string.IsNullOrWhiteSpace(dto.Email))
                user.Email = dto.Email;

            user.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(user);

            return true;
        }

    }
}

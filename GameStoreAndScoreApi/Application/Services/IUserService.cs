using GameStoreAndScoreApi.Application.DTOs;
using GameStoreAndScoreApi.Domain.Entities;

namespace GameStoreAndScoreApi.Application.Services
{
    public interface IUserService
    {
        Task<int> CreateAsync(CreateUserDto dto);

        Task<User?> GetByIdAsync(int id);

        Task<bool> UpdateAsync(int id, UpdateUserDto dto);
    }
}

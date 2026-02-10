using GameStoreAndScoreApi.Domain.Entities;

namespace GameStoreAndScoreApi.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(User user);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        Task UpdateAsync(User user);
    }
}

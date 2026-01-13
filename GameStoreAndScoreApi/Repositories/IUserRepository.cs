using GameStoreAndScoreApi.Models;

namespace GameStoreAndScoreApi.Repositories
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(User user);
        Task<User?> GetByEmailAsync(string email);
    }
}

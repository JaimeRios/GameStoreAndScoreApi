using GameStoreAndScoreApi.DTOs;

namespace GameStoreAndScoreApi.Services
{
    public interface IUserService
    {
        Task<int> CreateAsync(CreateUserDto dto);

        int Create(CreateUserDto userDto);

        string GetById(int id);
    }
}

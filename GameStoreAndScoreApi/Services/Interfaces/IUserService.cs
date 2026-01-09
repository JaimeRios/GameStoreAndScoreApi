using GameStoreAndScoreApi.DTOs;

namespace GameStoreAndScoreApi.Services.Interfaces
{
    public interface IUserService
    {
        int Create(CreateUserDto userDto);

        string GetById(int id);
    }
}

using AvaliacaoPW.Application.Dtos;

namespace AvaliacaoPW.Application.Interfaces;

public interface IUserService
{
    Task<Object> Login(LoginDto model);
    Task<Object> Create(UserDto model);
    Task<UserDto> Update(UserDto model, int userId);
    Task<UserDto> GetById(int id);
}

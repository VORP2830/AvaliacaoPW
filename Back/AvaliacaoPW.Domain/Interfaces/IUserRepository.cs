using AvaliacaoPW.Domain.Entities;

namespace AvaliacaoPW.Domain.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetByLogin(string login);
    Task<User> GetById(int id);
}
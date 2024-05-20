using AvaliacaoPW.Domain.Entities;

namespace AvaliacaoPW.Domain.Interfaces;

public interface IClientRepository : IGenericRepository<Client>
{
    Task<Client> GetById(int id);
}
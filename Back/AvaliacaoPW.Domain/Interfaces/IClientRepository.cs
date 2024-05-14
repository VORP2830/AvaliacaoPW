using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Pagination;

namespace AvaliacaoPW.Domain.Interfaces;

public interface IClientRepository : IGenericRepository<Client>
{
    Task<Client> GetById(int id);
}
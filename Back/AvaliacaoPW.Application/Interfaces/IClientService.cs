using AvaliacaoPW.Application.Dtos;
using AvaliacaoPW.Domain.Pagination;

namespace AvaliacaoPW.Application.Interfaces;

public interface IClientService
{
    Task<ClientDto> GetById(int id);
    Task<IEnumerable<ClientDto>> GetAll();
    Task<PageList<ClientDto>> GetPaginated(PageParams pageParams);
    Task<ClientDto> Create(ClientDto model);
    Task<ClientDto> Update(ClientDto model);
    Task<ClientDto> Delete(int id);
}

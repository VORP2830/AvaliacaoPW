using AutoMapper;
using AvaliacaoPW.Application.Dtos;
using AvaliacaoPW.Application.Interfaces;
using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Exceptions;
using AvaliacaoPW.Domain.Interfaces;
using AvaliacaoPW.Domain.Pagination;

namespace AvaliacaoPW.Application.Services;

public class ClientService : IClientService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public ClientService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ClientDto> GetById(int id)
    {
        Client client = await _unitOfWork.ClientRepository.GetById(id);
        return _mapper.Map<ClientDto>(client);
    }
    public async Task<IEnumerable<ClientDto>> GetAll()
    {
        IEnumerable<Client> clients = await _unitOfWork.ClientRepository.GetAll();
        return _mapper.Map<IEnumerable<ClientDto>>(clients);
    }
    public async Task<PageList<ClientDto>> GetPaginated(PageParams pageParams)
    {
        var clientPage = await _unitOfWork.ClientRepository.GetPaginated(pageParams);
        if (clientPage == null) return null;
        var clientPageDtos = _mapper.Map<IEnumerable<ClientDto>>(clientPage.Items);
        return new PageList<ClientDto>(clientPageDtos.ToList(), clientPage.TotalCount, clientPage.CurrentPage, clientPage.PageSize);
    }
    public async Task<ClientDto> Create(ClientDto model)
    {
        Client client = _mapper.Map<Client>(model);
        _unitOfWork.ClientRepository.Add(client);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ClientDto>(client);

    }
    public async Task<ClientDto> Update(ClientDto model)
    {
        Client client = await _unitOfWork.ClientRepository.GetById(model.Id);
        if(client is null)
        {
            throw new AvaliacaoPWException("Cliente não encontrado");
        }
        _mapper.Map(model, client);
        _unitOfWork.ClientRepository.Update(client);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ClientDto>(client);
    }
    public async Task<ClientDto> Delete(int id)
    {
        Client client = await _unitOfWork.ClientRepository.GetById(id);
        if(client is null)
        {
            throw new AvaliacaoPWException("Cliente não encontrado");
        }
        client.SetActive(false);
        _unitOfWork.ClientRepository.Update(client);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ClientDto>(client);
    }
}

using AutoMapper;
using AvaliacaoPW.Domain.Entities;

namespace AvaliacaoPW.Application.Dtos.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<Client, ClientDto>().ReverseMap();
    }
}
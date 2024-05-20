namespace AvaliacaoPW.Application.Dtos;

public class ClientDto : BaseEntity
{
    public string Title { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string CompanyName { get; set; }
    public AddressDto? Address { get; set; }
}

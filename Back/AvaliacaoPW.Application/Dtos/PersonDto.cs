namespace AvaliacaoPW.Application.Dtos;

public class PersonDto : BaseEntity
{
    public string Title { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public AddressDto? Address { get; set; }
}

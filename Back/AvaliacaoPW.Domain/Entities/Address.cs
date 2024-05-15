namespace AvaliacaoPW.Domain.Entities;

public class Address : BaseEntity
{
    public string StreetAvenue { get; set; }
    public string District { get; set; }
    public string ZipCode { get; set; }
    public string? Number { get; set; }
    public string? Complement { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    protected Address()
    {
        Active = true;
    }
}
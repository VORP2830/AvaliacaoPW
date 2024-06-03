namespace AvaliacaoPW.Domain.Entities;

public class Client : Person
{
    public string CompanyName { get; set; }
    public Client()
    {
        Active = true;
    }
}

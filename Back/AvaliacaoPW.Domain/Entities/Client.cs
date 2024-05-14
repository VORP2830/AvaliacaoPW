namespace AvaliacaoPW.Domain.Entities;

public abstract class Client : BaseEntity
{
    public string Title { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public Address Address { get; set; }
    protected Client()
    {
        Active = true;
    }
}
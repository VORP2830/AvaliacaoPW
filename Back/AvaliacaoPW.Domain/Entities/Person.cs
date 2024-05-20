namespace AvaliacaoPW.Domain.Entities;

public abstract class Person : BaseEntity
{
    public string Title { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public Address Address { get; set; }
    protected Person()
    {
        Active = true;
    }
}
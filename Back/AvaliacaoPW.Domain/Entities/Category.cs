namespace AvaliacaoPW.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string CompanyName { get; set; }
    public Category()
    {
        Active = true;
    }
}

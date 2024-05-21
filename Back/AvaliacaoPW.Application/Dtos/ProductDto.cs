namespace AvaliacaoPW.Application.Dtos;

public class ProductDto : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int InStock { get; set; }
    public int InOrder { get; set; }
    public int CategoryId { get; set; }
    public CategoryDto? Category { get; set; }
}

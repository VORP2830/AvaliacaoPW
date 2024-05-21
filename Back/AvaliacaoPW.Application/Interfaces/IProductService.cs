using AvaliacaoPW.Application.Dtos;
using AvaliacaoPW.Domain.Pagination;

namespace AvaliacaoPW.Application.Interfaces;

public interface IProductService
{
    Task<ProductDto> GetById(int id);
    Task<IEnumerable<ProductDto>> GetAll();
    Task<PageList<ProductDto>> GetPaginated(PageParams pageParams);
    Task<ProductDto> Create(ProductDto model);
    Task<ProductDto> Update(ProductDto model);
    Task<ProductDto> Delete(int id);
}

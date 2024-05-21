using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Pagination;

namespace AvaliacaoPW.Domain.Interfaces;
public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product> GetById(int id);
    Task<IEnumerable<Product>> GetAll();
    Task<PageList<Product>> GetPaginated(PageParams pageParams);
}

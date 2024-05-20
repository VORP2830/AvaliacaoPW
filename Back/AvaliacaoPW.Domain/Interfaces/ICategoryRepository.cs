using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Pagination;

namespace AvaliacaoPW.Domain.Interfaces;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<Category> GetById(int id);
    Task<IEnumerable<Category>> GetAll();
    Task<PageList<Category>> GetPaginated(PageParams pageParams);
}
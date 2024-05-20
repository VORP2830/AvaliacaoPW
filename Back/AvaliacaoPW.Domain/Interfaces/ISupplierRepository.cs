using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Pagination;

namespace AvaliacaoPW.Domain.Interfaces;
public interface ISupplierRepository : IGenericRepository<Supplier>
{
    Task<Supplier> GetById(int id);
    Task<IEnumerable<Supplier>> GetAll();
    Task<PageList<Supplier>> GetPaginated(PageParams pageParams);
}
using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Pagination;

namespace AvaliacaoPW.Domain.Interfaces;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<Employee> GetById(int id);
    Task<IEnumerable<Employee>> GetAll();
    Task<PageList<Employee>> GetPaginated(PageParams pageParams);
}

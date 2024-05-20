using AvaliacaoPW.Application.Dtos;
using AvaliacaoPW.Domain.Pagination;

namespace AvaliacaoPW.Application.Interfaces;

public interface IEmployeeService
{
    Task<EmployeeDto> GetById(int id);
    Task<IEnumerable<EmployeeDto>> GetAll();
    Task<PageList<EmployeeDto>> GetPaginated(PageParams pageParams);
    Task<EmployeeDto> Create(EmployeeDto model);
    Task<EmployeeDto> Update(EmployeeDto model);
    Task<EmployeeDto> Delete(int id);
}
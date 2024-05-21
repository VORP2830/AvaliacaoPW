using AvaliacaoPW.Application.Dtos;
using AvaliacaoPW.Domain.Pagination;

namespace AvaliacaoPW.Application.Interfaces;

public interface ISupplierService
{
    Task<SupplierDto> GetById(int id);
    Task<IEnumerable<SupplierDto>> GetAll();
    Task<PageList<SupplierDto>> GetPaginated(PageParams pageParams);
    Task<SupplierDto> Create(SupplierDto model);
    Task<SupplierDto> Update(SupplierDto model);
    Task<SupplierDto> Delete(int id);
}

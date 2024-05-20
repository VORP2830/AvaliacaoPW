using AvaliacaoPW.Application.Dtos;
using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Pagination;

namespace AvaliacaoPW.Application.Interfaces;

public interface ICategoryService
{
    Task<CategoryDto> GetById(int id);
    Task<IEnumerable<CategoryDto>> GetAll();
    Task<PageList<CategoryDto>> GetPaginated(PageParams pageParams);
    Task<CategoryDto> Create(CategoryDto model);
    Task<CategoryDto> Update(CategoryDto model);
    Task<CategoryDto> Delete(int id);
}

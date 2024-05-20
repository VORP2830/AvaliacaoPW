using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Interfaces;
using AvaliacaoPW.Domain.Pagination;
using AvaliacaoPW.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoPW.Infra.Data.Repositories;

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<PageList<Category>> GetPaginated(PageParams pageParams)
    {
        var query = _context.Categories
                                .AsNoTracking()
                                .Where(p => p.Active);

        query = query.OrderBy(e => e.Name);

        var totalCount = await query.CountAsync();

        var items = await query.Skip((pageParams.PageNumber - 1) * pageParams.PageSize)
                            .Take(pageParams.PageSize)
                            .ToListAsync();

        return new PageList<Category>(items, totalCount, pageParams.PageNumber, pageParams.PageSize);
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _context.Categories
                                .AsNoTracking()
                                .Where(p => p.Active)
                                .ToListAsync();
    }

    public async Task<Category> GetById(int id)
    {
        return await _context.Categories
                                .AsNoTracking()
                                .FirstOrDefaultAsync(d => d.Active && 
                                                            d.Id == id);
    }
}
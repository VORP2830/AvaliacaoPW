using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Interfaces;
using AvaliacaoPW.Domain.Pagination;
using AvaliacaoPW.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoPW.Infra.Data.Repositories;
public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<PageList<Product>> GetPaginated(PageParams pageParams)
    {
        var query = _context.Products
                                .AsNoTracking()
                                .Where(p => p.Active);

        query = query.OrderBy(e => e.Name);

        var totalCount = await query.CountAsync();

        var items = await query.Skip((pageParams.PageNumber - 1) * pageParams.PageSize)
                            .Take(pageParams.PageSize)
                            .ToListAsync();

        return new PageList<Product>(items, totalCount, pageParams.PageNumber, pageParams.PageSize);
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products
                                .AsNoTracking()
                                .Where(p => p.Active)
                                .ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        return await _context.Products
                                .AsNoTracking()
                                .FirstOrDefaultAsync(d => d.Active &&
                                                            d.Id == id);
    }
}

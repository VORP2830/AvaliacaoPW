using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Interfaces;
using AvaliacaoPW.Domain.Pagination;
using AvaliacaoPW.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoPW.Infra.Data.Repositories;
public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
{
    private readonly ApplicationDbContext _context;
    public SupplierRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await _context.Suppliers
                                .AsNoTracking()
                                .Where(p => p.Active)
                                .ToListAsync();
        }
        public async Task<Supplier> GetById(int id)
        {
            return await _context.Suppliers
                                .AsNoTracking()
                                .Include(d => d.Address)
                                .FirstOrDefaultAsync(d => d.Active &&
                                                            d.Id == id);
        }
        public async Task<PageList<Supplier>> GetPaginated(PageParams pageParams)
        {
            var query = _context.Suppliers
                                .AsNoTracking()
                                .Where(p => p.Active);

        query = query.OrderBy(e => e.Name);

        var totalCount = await query.CountAsync();

        var items = await query.Skip((pageParams.PageNumber - 1) * pageParams.PageSize)
                            .Take(pageParams.PageSize)
                            .ToListAsync();

        return new PageList<Supplier>(items, totalCount, pageParams.PageNumber, pageParams.PageSize);
        }
}

using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Interfaces;
using AvaliacaoPW.Domain.Pagination;
using AvaliacaoPW.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoPW.Infra.Data.Repositories;

public class ClientRepository : GenericRepository<Client>, IClientRepository
{
    private readonly ApplicationDbContext _context;
    public ClientRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<PageList<Client>> GetPaginated(PageParams pageParams)
    {
        var query = _context.Clients
                                .AsNoTracking()
                                .Where(p => p.Active);

        query = query.OrderBy(e => e.Name);

        var totalCount = await query.CountAsync();

        var items = await query.Skip((pageParams.PageNumber - 1) * pageParams.PageSize)
                            .Take(pageParams.PageSize)
                            .ToListAsync();

        return new PageList<Client>(items, totalCount, pageParams.PageNumber, pageParams.PageSize);
    }

    public async Task<IEnumerable<Client>> GetAll()
    {
        return await _context.Clients
                                .AsNoTracking()
                                .Where(p => p.Active)
                                .ToListAsync();
    }

    public async Task<Client> GetById(int id)
    {
        return await _context.Clients
                                .AsNoTracking()
                                .Include(d => d.Address)
                                .FirstOrDefaultAsync(d => d.Active && 
                                                            d.Id == id);
    }
}
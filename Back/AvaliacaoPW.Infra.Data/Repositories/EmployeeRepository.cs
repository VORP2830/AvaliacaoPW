using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Interfaces;
using AvaliacaoPW.Domain.Pagination;
using AvaliacaoPW.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoPW.Infra.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees
                                .AsNoTracking()
                                .Where(p => p.Active)
                                .ToListAsync();
        }
        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees
                                .AsNoTracking()
                                .Include(d => d.Address)
                                .FirstOrDefaultAsync(d => d.Active &&
                                                            d.Id == id);
        }
        public async Task<PageList<Employee>> GetPaginated(PageParams pageParams)
        {
            var query = _context.Employees
                                .AsNoTracking()
                                .Where(p => p.Active);

        query = query.OrderBy(e => e.Name);

        var totalCount = await query.CountAsync();

        var items = await query.Skip((pageParams.PageNumber - 1) * pageParams.PageSize)
                            .Take(pageParams.PageSize)
                            .ToListAsync();

        return new PageList<Employee>(items, totalCount, pageParams.PageNumber, pageParams.PageSize);
        }
    }
}
using AvaliacaoPW.Domain.Interfaces;
using AvaliacaoPW.Infra.Data.Context;

namespace AvaliacaoPW.Infra.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    public IUserRepository UserRepository => new UserRepository(_context);
    public IClientRepository ClientRepository => new ClientRepository(_context);
    public IEmployeeRepository EmployeeRepository => new EmployeeRepository(_context);
    public ICategoryRepository CategoryRepository => new CategoryRepository(_context);
    public ISupplierRepository SupplierRepository => new SupplierRepository(_context);
    public IProductRepository ProductRepository => new ProductRepository(_context);

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }
}
namespace AvaliacaoPW.Domain.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IClientRepository ClientRepository { get; }
    IEmployeeRepository EmployeeRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    ISupplierRepository SupplierRepository { get; }
    Task<bool> SaveChangesAsync();
}
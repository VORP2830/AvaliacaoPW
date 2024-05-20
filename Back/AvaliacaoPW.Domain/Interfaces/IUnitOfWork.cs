namespace AvaliacaoPW.Domain.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IClientRepository ClientRepository { get; }
    IEmployeeRepository EmployeeRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    Task<bool> SaveChangesAsync();
}
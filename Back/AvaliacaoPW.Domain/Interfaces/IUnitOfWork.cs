namespace AvaliacaoPW.Domain.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    Task<bool> SaveChangesAsync();
}
namespace AvaliacaoPW.Domain.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IClientRepository ClientRepository { get; }
    Task<bool> SaveChangesAsync();
}
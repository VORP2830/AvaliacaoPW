namespace AvaliacaoPW.Domain.Interfaces;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync();
}
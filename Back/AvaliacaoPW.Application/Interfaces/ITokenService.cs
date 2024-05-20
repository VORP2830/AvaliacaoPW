namespace AvaliacaoPW.Application.Interfaces;

public interface ITokenService
{
    Task<string> GenerateToken(int userId, string login, string companyName);
}
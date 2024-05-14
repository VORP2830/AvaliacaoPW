using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Interfaces;
using AvaliacaoPW.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoPW.Infra.Data.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByLogin(string login)
    {
        return await _context.Users 
                                .AsNoTracking()
                                .FirstOrDefaultAsync(u => u.Active &&
                                                            u.Login == login);
    }

    public async Task<User> GetById(int id)
    {
        return await _context.Users
                                .AsNoTracking()
                                .Include(u => u.Address)
                                .FirstOrDefaultAsync(d => d.Active && 
                                                            d.Id == id);
    }
}
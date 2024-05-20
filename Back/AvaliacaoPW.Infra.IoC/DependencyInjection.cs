using System.Text.Json.Serialization;
using AvaliacaoPW.Application.Dtos.Mapping;
using AvaliacaoPW.Application.Interfaces;
using AvaliacaoPW.Application.Services;
using AvaliacaoPW.Domain.Interfaces;
using AvaliacaoPW.Infra.Data.Context;
using AvaliacaoPW.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AvaliacaoPW.Infra.IoC;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("DATABASE") ?? configuration.GetConnectionString("DefaultConnection");
            service.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        
        service.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        
        service.AddAutoMapper(typeof(MappingProfile));

        service.AddScoped<IUnitOfWork, UnitOfWork>();

        service.AddScoped<ITokenService, TokenService>();
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IClientService, ClientService>();
        service.AddScoped<IEmployeeService, EmployeeService>();
        service.AddScoped<ICategoryService, CategoryService>();

        return service;
    }
}
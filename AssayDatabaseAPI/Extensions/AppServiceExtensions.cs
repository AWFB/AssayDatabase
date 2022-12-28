using AssayDatabaseAPI.Data;
using AssayDatabaseAPI.Interfaces;
using AssayDatabaseAPI.Repositories;
using AssayDatabaseAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace AssayDatabaseAPI.Extensions;

public static class AppServiceExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });

        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRepo, UserRepo>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
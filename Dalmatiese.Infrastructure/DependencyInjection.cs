using Dalmatiese.Application.Common.Interfaces.Authentication;
using Dalmatiese.Application.Common.Interfaces.Persistence;
using Dalmatiese.Application.Common.Interfaces.Services;
using Dalmatiese.Infrastructure.Authentication;
using Dalmatiese.Infrastructure.Persistence;
using Dalmatiese.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dalmatiese.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure( this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
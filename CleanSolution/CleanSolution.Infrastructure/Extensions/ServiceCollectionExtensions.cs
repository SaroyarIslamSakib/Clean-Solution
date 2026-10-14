using CleanSolution.Domain;
using CleanSolution.Domain.Repositories;
using CleanSolution.Infrastructure.Data;
using CleanSolution.Infrastructure.Repositories;
using Cortex.Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanSolution.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection service)
        {
            service.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
            service.AddScoped<IApplicationSettingRepository, ApplicationSettingRepository>();
           
        }
        public static void AddDbContext(this IServiceCollection service,string connectionString, Assembly migrationAssembly)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString,
                (x) => x.MigrationsAssembly(migrationAssembly)));

        }
    }
}

using ABCSAC.Infrastructure.Persistences.Context;
using ABCSAC.Infrastructure.Persistences.Interfaces;
using ABCSAC.Infrastructure.Persistences.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCSAC.Infrastructure.Persistences.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(DBContext).Assembly.FullName;

            services.AddDbContext<DBContext>(
                options => options.UseSqlServer(
                                                    configuration.GetConnectionString("ABCConecction"), b => b.MigrationsAssembly(assembly)
                                               ), ServiceLifetime.Transient
                                             );

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}

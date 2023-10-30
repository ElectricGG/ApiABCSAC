using ABCSAC.Application.Extensions.WatchDog;
using ABCSAC.Application.Interfaces;
using ABCSAC.Application.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ABCSAC.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
                                                                                                                                                                                    #pragma warning disable CS0618 // El tipo o el miembro están obsoletos
            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
            });
                                                                                                                                                                                                    #pragma warning restore CS0618 // El tipo o el miembro están obsoletos

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IEmpleadoApplication, EmpleadoApplication>();
            services.AddScoped<IAfpApplication, AfpApplication>();
            services.AddScoped<ICargoApplication, CargoApplication>();


            services.AddWAtchDog(configuration);

            return services;
        }
    }
}

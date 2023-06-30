using Core.Interfaces.Base;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Infrastructure.Persistence.Base;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Repository;
using Infrastructure.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.ServiceCollection
{
    public static class ApplicationDependencies
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IDbFactory<PropertiesInformationContext>, DbFactory<PropertiesInformationContext>>();
            services.AddScoped<IUnitOfWork<PropertiesInformationContext>, UnitOfWork<PropertiesInformationContext>>();

            /* Repositorios. */
            services.AddTransient<IPropertyRepository<PropertiesInformationContext>, PropertyRepository>();
            services.AddTransient<IOwnerRepository<PropertiesInformationContext>, OwnerRepository>();
            services.AddTransient<IFilesRepository, FilesRepository>();
            services.AddTransient<IPropertyImageRepository<PropertiesInformationContext>, PropertyImageRepository>();
            services.AddTransient<IPropertyTraceRepository<PropertiesInformationContext>, PropertyTraceRepository>();
            /* Servicios. */
            services.AddTransient<IPropertyService, PropertyService>();
            services.AddTransient<IPropertyImageService, PropertyImageService>();
            services.AddTransient<IPropertyTraceService, PropertyTraceService>();

            return services;
        }
    }
}

using Infrastructure.Persistence.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions.ServiceCollection
{
    public static class DatabaseContextFactory
    {
        public static IServiceCollection AddDbFactory(this IServiceCollection services)
        {
            services.AddScoped<Func<PropertiesInformationContext>>((provider) => () => provider.GetService<PropertiesInformationContext>());
            return services;
        }
    }
}

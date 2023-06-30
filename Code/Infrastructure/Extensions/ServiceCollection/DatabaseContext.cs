﻿using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions.ServiceCollection
{
    public static class DatabaseContext
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<PropertiesInformationContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("PropertiesInformationContext"));
            });
            return services;
        }
    }
}

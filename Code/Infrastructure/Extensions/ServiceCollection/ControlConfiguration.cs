using Core.DTO;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Filters;
using Infrastructure.Middleware;
using Infrastructure.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Extensions.ServiceCollection
{
    public static class ControlConfiguration
    {
        public static IServiceCollection AddControllersExtend(this IServiceCollection services)
        {
            services.AddTransient<ErrorHandlerMiddleware>();
            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalValidationFilterAttribute>();
            }).ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            }).AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
            });
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}

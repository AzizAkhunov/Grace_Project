using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Grace_Project.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

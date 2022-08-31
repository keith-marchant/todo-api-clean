using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Application.Interfaces;
using TodoApp.Infrastructure.Persistence;
using TodoApp.Infrastructure.Services;

namespace TodoApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IItemRepository, ItemRepository>();

            if (!string.IsNullOrEmpty(configuration.GetConnectionString("TodoDb")))
            {
                services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("TodoDb")));
            }
            else
            {
                services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("TodoDb"));
            }

            return services;
        }
    }
}

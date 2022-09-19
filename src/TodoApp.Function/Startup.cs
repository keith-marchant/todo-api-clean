using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Application;
using TodoApp.Infrastructure;

[assembly: FunctionsStartup(typeof(TodoApp.Function.Startup))]
namespace TodoApp.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.GetContext().Configuration);
            builder.Services.AddHttpContextAccessor();
        }
    }
}

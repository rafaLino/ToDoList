using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ToDo.Infrastructure.IoCManager
{
    public static class IoCManager
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            AddContext(services);
            AddRepositories(services);
            AddServices(services);
        }
        public static void AddConfig(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<ToDoAppConfig>(config.GetSection(ToDoAppConfig.Configuration));
        }

        public static void AddContext(IServiceCollection services)
        {
            services.AddSingleton<Context>();
        }

        public static void AddRepositories(IServiceCollection services)
        {
            const string suffix = "Repository";
            var types = typeof(IoCManager).Assembly
                .GetTypes()
                .Where(type => !type.IsAbstract &&
                    type.Name.EndsWith(suffix, System.StringComparison.InvariantCultureIgnoreCase) &&
                    type.GetInterfaces().First().Name.EndsWith(suffix, System.StringComparison.InvariantCultureIgnoreCase)
                );

            foreach (var type in types)
            {
                services.AddScoped(type.GetInterfaces().First(), type);
            }
        }


        public static void AddServices(IServiceCollection services)
        {
            const string suffix = "UseCase";
            var types = typeof(IoCManager).Assembly
                .GetTypes()
                .Where(type => !type.IsAbstract &&
                    type.Name.EndsWith(suffix, System.StringComparison.InvariantCultureIgnoreCase) &&
                    type.GetInterfaces().First().Name.EndsWith(suffix, System.StringComparison.InvariantCultureIgnoreCase)
                );

            foreach (var type in types)
            {
                services.AddScoped(type.GetInterfaces().First(), type);
            }
        }
    }
}

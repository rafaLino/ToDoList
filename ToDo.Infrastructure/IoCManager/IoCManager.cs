using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace ToDo.Infrastructure.IoCManager
{
    public static class IoCManager
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            AddContext(services);
            AddRepositories(services);
            AddServices(services);
            AddQueries(services);
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
                foreach (var interfaceType in type.GetInterfaces())
                {
                    services.AddScoped(interfaceType, type);
                }
            }
        }


        public static void AddServices(IServiceCollection services)
        {
            const string suffix = "UseCase";
            Assembly applicationAssembly = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Single(x => x.GetName().Name == "ToDo.Application");
            var types = applicationAssembly
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

        public static void AddQueries(IServiceCollection services)
        {
            const string suffix = "Queries";
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

using AutoMapper;
using IntravisionTestTask.DAL.EF;
using IntravisionTestTask.Domain.Definitions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IntravisionTestTask.API.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void ConfigureDbContext(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var sqlServerProvider = builder.Configuration.GetValue<string>(Constants.Configurations.SQLProviderKey);
            var connectionString = builder.Configuration.GetConnectionString(sqlServerProvider);
            var migrationAssembly = string.Concat(Constants.CommonAssemblyName, '.', sqlServerProvider);

            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(connectionString, o => o.MigrationsAssembly(migrationAssembly));
            });
        }

        public static void ConfigureAutoMapper(this IServiceCollection services, params Assembly[] assembliesToScan)
        {
            var mapperConfigurations = new MapperConfiguration(config => config.AddMaps(assembliesToScan));
            var mapper = mapperConfigurations.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

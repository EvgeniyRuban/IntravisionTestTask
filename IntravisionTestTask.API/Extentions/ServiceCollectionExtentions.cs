using IntravisionTestTask.DAL.EF;
using IntravisionTestTask.Domain.Definitions;
using Microsoft.EntityFrameworkCore;

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
    }
}

using AutoMapper;
using IntravisionTestTask.Business.Services;
using IntravisionTestTask.DAL.EF;
using IntravisionTestTask.DAL.Repositories;
using IntravisionTestTask.Domain.Definitions;
using IntravisionTestTask.Domain.Repositories;
using IntravisionTestTask.Domain.Services;
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

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductSlotRepository, ProductSlotRepository>();
            services.AddScoped<IProductMachineRepository, ProductMachineRepository>();

            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductSlotService, ProductSlotService>();
            services.AddScoped<IProductMachineService, ProductMachineService>();
        }
    }
}

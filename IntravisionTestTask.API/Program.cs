using IntravisionTestTask.DAL.EF;
using IntravisionTestTask.Domain.Definitions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlServerProvider = builder.Configuration.GetValue<string>(Constants.Configurations.SQLProviderKey);
var connectionString = builder.Configuration.GetConnectionString(sqlServerProvider);
var migrationAssembly = string.Concat(Constants.CommonAssemblyName, '.', sqlServerProvider);

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(connectionString, o => o.MigrationsAssembly(migrationAssembly));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
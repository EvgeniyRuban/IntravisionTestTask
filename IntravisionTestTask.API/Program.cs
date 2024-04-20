using IntravisionTestTask.API.Extentions;
using IntravisionTestTask.Domain.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDbContext(builder);
builder.Services.ConfigureAutoMapper(typeof(ProductTypeProfile).Assembly);
builder.Services.RegistrateServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
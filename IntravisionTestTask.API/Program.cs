using IntravisionTestTask.API.Extentions;
using IntravisionTestTask.Domain.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDbContext(builder);
builder.Services.ConfigureAutoMapper(typeof(ProductTypeProfile).Assembly);
builder.Services.RegisterServices();

var app = builder.Build();

app.UseCors(options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());
app.ConfigureExceptionHandler(app.Logger);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
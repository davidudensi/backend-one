using BackendOne.API.Interfaces;
using BackendOne.API.Services;
using BackendOne.DataAccess.Access;
using BackendOne.DataAccess.Config;
using BackendOne.DataAccess.Interfaces;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();
SetUpCors();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();


void SetUpCors()
{
    app.UseCors(
        options => options.SetIsOriginAllowed(x => _ = true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
    );
}

void ConfigureServices(IServiceCollection services)
{
    DbOptions options = new();
    builder.Configuration.Bind("ConnectionStrings", options);
    services.AddSingleton(options);

    services.AddTransient<IProduct, ProductService>();
    services.AddTransient<IProductAccess, ProductAccess>();
    services.AddTransient<IDatabase, Database>();
}

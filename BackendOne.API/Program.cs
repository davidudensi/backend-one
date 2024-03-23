var builder = WebApplication.CreateBuilder(args);

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

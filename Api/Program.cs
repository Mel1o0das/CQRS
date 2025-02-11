using Application;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConfiguration(
    builder.Configuration.GetSection("Logging")
);
builder.Logging.AddConsole();


builder.Services
    .AddApiServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApplictionServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    await app.InitializeDatabaseAsync();
}

app.UseApiServices();

app.Run();

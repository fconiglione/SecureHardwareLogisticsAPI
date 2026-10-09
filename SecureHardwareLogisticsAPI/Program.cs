using Microsoft.EntityFrameworkCore;
using SecureHardwareLogisticsAPI.Data;
using SecureHardwareLogisticsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Connecting to DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IMaintenanceRequestService, MaintenanceRequestService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
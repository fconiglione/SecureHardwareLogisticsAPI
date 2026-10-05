using Microsoft.EntityFrameworkCore;
using SecureHardwareLogisticsAPI.Models;

namespace SecureHardwareLogisticsAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<HardwareAsset> HardwareAssets { get; set; } = null!;
    public DbSet<AuditLog> AuditLogs { get; set; } = null!;
}
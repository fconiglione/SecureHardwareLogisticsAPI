namespace SecureHardwareLogisticsAPI.Models;

public class AuditLog
{
    public int Id { get; set; }
    public int HardwareAssetId { get; set; }
    public string Action { get; set; } = null!;
    public DateTime Timestamp { get; set; }
    public HardwareAsset Asset { get; set; } = null!;
}
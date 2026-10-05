namespace SecureHardwareLogisticsAPI.DTOs.Responses;

public class AssetDetailDto
{
    public int Id { get; set; }
    public int HardwareAssetId { get; set; }
    public string Action { get; set; } = null!;
    public DateTime Timestamp { get; set; }
}
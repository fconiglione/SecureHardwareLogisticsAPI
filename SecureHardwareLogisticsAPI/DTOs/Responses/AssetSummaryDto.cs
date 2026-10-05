namespace SecureHardwareLogisticsAPI.DTOs.Responses;

public class AssetSummaryDto
{
    public int Id { get; set; }
    public string SerialNumber { get; set; } = null!;
    public string DeviceModel { get; set; } = null!;
    public string Status { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}
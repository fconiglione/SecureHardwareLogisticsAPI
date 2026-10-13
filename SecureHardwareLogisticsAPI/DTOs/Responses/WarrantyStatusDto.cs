namespace SecureHardwareLogisticsAPI.DTOs.Responses;

public class WarrantyStatusDto
{
    public int AssetId { get; set; }
    public string WarrantyPlan { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CheckedAt { get; set; }
}
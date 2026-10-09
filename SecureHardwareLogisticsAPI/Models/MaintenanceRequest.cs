namespace SecureHardwareLogisticsAPI.Models;

public class MaintenanceRequest
{
    public int Id { get; set; }
    public int HardwareId { get; set; }
    public int ReportedMilitaryId { get; set; }
    public string Urgency { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}
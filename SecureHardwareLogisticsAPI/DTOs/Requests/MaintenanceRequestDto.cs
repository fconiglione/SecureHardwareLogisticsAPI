namespace SecureHardwareLogisticsAPI.DTOs.Requests;

public class MaintenanceRequestDto
{
    public int HardwareId { get; set; }
    public int ReportedMilitaryId { get; set; }
    public string Urgency { get; set; } = null!;
    public string Description { get; set; } = null!;
}
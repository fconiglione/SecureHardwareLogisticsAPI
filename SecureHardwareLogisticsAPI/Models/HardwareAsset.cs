namespace SecureHardwareLogisticsAPI.Models;

public class HardwareAsset
{
    public int Id { get; set; }
    public string SerialNumber { get; set; } = null!;
    public string DeviceModel { get; set; } = null!;
    public string? AssignedMilitaryId { get; set; }
    public string Status { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public HardwareAsset(string SerialNumber, string DeviceModel)
    {
        this.SerialNumber = SerialNumber;
        this.DeviceModel = DeviceModel;
        
        CreatedAt= DateTime.UtcNow;
        Status = "In Inventory";
    }
}
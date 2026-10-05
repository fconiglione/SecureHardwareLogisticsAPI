using SecureHardwareLogisticsAPI.Data;
using SecureHardwareLogisticsAPI.DTOs.Requests;
using SecureHardwareLogisticsAPI.DTOs.Responses;
using SecureHardwareLogisticsAPI.Models;

namespace SecureHardwareLogisticsAPI.Services;

public class AssetService : IAssetService
{
    private readonly AppDbContext _context;
    
    public AssetService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<AssetSummaryDto> ProvisionAssetAsync(ProvisionAssetDto request)
    {
        var generatedSerial = $"SN-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";

        var newAsset = new HardwareAsset(generatedSerial, request.DeviceModel);

        newAsset.AuditLogs.Add(new AuditLog 
        { 
            Action = "Asset provisioned into secure inventory",
            Timestamp = DateTime.UtcNow
        });

        _context.HardwareAssets.Add(newAsset);
        await _context.SaveChangesAsync();

        return new AssetSummaryDto
        {
            Id = newAsset.Id,
            SerialNumber = newAsset.SerialNumber,
            DeviceModel = newAsset.DeviceModel,
            Status = newAsset.Status,
            CreatedAt = newAsset.CreatedAt
        };
    }
}
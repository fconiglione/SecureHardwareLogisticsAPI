using SecureHardwareLogisticsAPI.DTOs.Requests;
using SecureHardwareLogisticsAPI.DTOs.Responses;

namespace SecureHardwareLogisticsAPI.Services;

public interface IAssetService
{
    Task<AssetSummaryDto> ProvisionAssetAsync(ProvisionAssetDto request);
}
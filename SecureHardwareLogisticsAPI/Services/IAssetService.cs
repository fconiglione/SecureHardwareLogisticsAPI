using SecureHardwareLogisticsAPI.DTOs.Requests;
using SecureHardwareLogisticsAPI.DTOs.Responses;

namespace SecureHardwareLogisticsAPI.Services;

public interface IAssetService
{
    Task<AssetSummaryDto> ProvisionAssetAsync(ProvisionAssetDto request);
    Task<AssetSummaryDto> AssignAssetAsync(int id, AssignAssetDto request);
    Task<IEnumerable<AssetSummaryDto>> GetAssetsAsync();
    Task<AssetSummaryDto?> GetAssetAsync(int id);
    Task<IEnumerable<AssetDetailDto>> GetLogHistoryAsync(int id);
}
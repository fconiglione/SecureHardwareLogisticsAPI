using SecureHardwareLogisticsAPI.DTOs.Requests;
using SecureHardwareLogisticsAPI.DTOs.Responses;

namespace SecureHardwareLogisticsAPI.Services;

public interface IMaintenanceRequestService
{
    public Task<MaintenanceSummaryDto> CreateMaintenanceRequestAsync(MaintenanceRequestDto maintenanceRequestDto);
}
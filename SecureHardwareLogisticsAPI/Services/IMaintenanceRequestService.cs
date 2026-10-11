using SecureHardwareLogisticsAPI.DTOs.Requests;
using SecureHardwareLogisticsAPI.DTOs.Responses;

namespace SecureHardwareLogisticsAPI.Services;

public interface IMaintenanceRequestService
{
    public Task<MaintenanceSummaryDto> CreateMaintenanceRequestAsync(MaintenanceRequestDto maintenanceRequestDto);
    public Task<MaintenanceSummaryDto> GetMaintenanceRequestAsync(int id);
    public Task<MaintenanceSummaryDto> UpdateMaintenanceRequestAsync(int id, UpdateMaintenanceRequestDto updateMaintenanceRequestDto);
}
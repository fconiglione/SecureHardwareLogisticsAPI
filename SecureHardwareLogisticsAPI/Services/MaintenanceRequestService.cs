using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SecureHardwareLogisticsAPI.DTOs.Requests;
using SecureHardwareLogisticsAPI.DTOs.Responses;

namespace SecureHardwareLogisticsAPI.Services;

public class MaintenanceRequestService : IMaintenanceRequestService
{
    private readonly DbContext _dbContext;
    
    public MaintenanceRequestService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<MaintenanceSummaryDto> CreateMaintenanceRequestAsync(MaintenanceRequestDto maintenanceRequestDto)
    {
        return null!;
    }
}
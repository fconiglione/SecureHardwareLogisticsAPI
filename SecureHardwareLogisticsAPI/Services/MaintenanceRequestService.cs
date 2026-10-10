using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SecureHardwareLogisticsAPI.Data;
using SecureHardwareLogisticsAPI.DTOs.Requests;
using SecureHardwareLogisticsAPI.DTOs.Responses;
using SecureHardwareLogisticsAPI.Models;

namespace SecureHardwareLogisticsAPI.Services;

public class MaintenanceRequestService : IMaintenanceRequestService
{
    private readonly AppDbContext _context;
    
    public MaintenanceRequestService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MaintenanceSummaryDto> CreateMaintenanceRequestAsync(MaintenanceRequestDto request)
    {
        var newMaintenanceRequest = new MaintenanceRequest(request.HardwareId, request.ReportedMilitaryId,
            request.Urgency, request.Description);

        _context.MaintenanceRequests.Add(newMaintenanceRequest);
        await _context.SaveChangesAsync();

        return new MaintenanceSummaryDto
        {
            Id = newMaintenanceRequest.Id,
            HardwareId = newMaintenanceRequest.HardwareId,
            ReportedMilitaryId = newMaintenanceRequest.ReportedMilitaryId,
            Status = newMaintenanceRequest.Status,
            Urgency = newMaintenanceRequest.Urgency,
            Description = newMaintenanceRequest.Description,
            CreatedAt = newMaintenanceRequest.CreatedAt,
        };
    }
}
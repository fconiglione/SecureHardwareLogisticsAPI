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

    public async Task<MaintenanceSummaryDto> GetMaintenanceRequestAsync(int id)
    {
        var maintenanceRequest = _context.MaintenanceRequests.FirstOrDefault(x => x.Id == id);

        if (maintenanceRequest == null)
        {
            return null;
        }
        
        return new MaintenanceSummaryDto{
            Id = maintenanceRequest.Id,
            HardwareId = maintenanceRequest.HardwareId,
            ReportedMilitaryId = maintenanceRequest.ReportedMilitaryId,
            Status = maintenanceRequest.Status,
            Urgency = maintenanceRequest.Urgency,
            Description = maintenanceRequest.Description,
            CreatedAt = maintenanceRequest.CreatedAt,
            };
    }

    public async Task<MaintenanceSummaryDto> UpdateMaintenanceRequestAsync(int id,
        UpdateMaintenanceRequestDto request)
    {
        var updatedMaintenanceRequest = _context.MaintenanceRequests.FirstOrDefault(x => id == x.Id);

        updatedMaintenanceRequest?.Status = request.Status;
        
        await  _context.SaveChangesAsync();

        return new MaintenanceSummaryDto
        {
            Id = updatedMaintenanceRequest.Id,
            HardwareId = updatedMaintenanceRequest.HardwareId,
            ReportedMilitaryId = updatedMaintenanceRequest.ReportedMilitaryId,
            Status = updatedMaintenanceRequest.Status,
            Urgency = updatedMaintenanceRequest.Urgency,
            Description = updatedMaintenanceRequest.Description,
            CreatedAt = updatedMaintenanceRequest.CreatedAt,
        };
    }
}
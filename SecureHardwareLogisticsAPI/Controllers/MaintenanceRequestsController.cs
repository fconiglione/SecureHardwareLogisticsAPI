using Microsoft.AspNetCore.Mvc;
using SecureHardwareLogisticsAPI.DTOs.Requests;
using SecureHardwareLogisticsAPI.Services;

namespace SecureHardwareLogisticsAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MaintenanceRequestsController: ControllerBase
{
    private readonly IMaintenanceRequestService _maintenanceRequestService;   
    
    public MaintenanceRequestsController(IMaintenanceRequestService maintenanceRequestService)
    {
        _maintenanceRequestService = maintenanceRequestService;
    }
    
    // Method to submit a MaintenanceRequest for an existing HardwareAsset item
    [HttpPost]
    public async Task<IActionResult> CreateMaintenanceRequest([FromBody] MaintenanceRequestDto request)
    {
        var result = await _maintenanceRequestService.CreateMaintenanceRequestAsync(request);

        return Created($"/api/v1/maintenancerequests/{result.Id}", result);
    }
    
    // Method to get a MaintenanceRequest by Id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMaintenanceRequest(int id)
    {
        var result = await _maintenanceRequestService.GetMaintenanceRequestAsync(id);
        return Ok(result);
    }
    
    // Method to update the Status of a MaintenanceRequest
    [HttpPut("{id}/update")]
    public async Task<IActionResult> UpdateMaintenanceRequestAsync(int id, [FromBody] UpdateMaintenanceRequestDto  request)
    {
        var result = await _maintenanceRequestService.UpdateMaintenanceRequestAsync(id, request);
        return Ok(result);
    }
}
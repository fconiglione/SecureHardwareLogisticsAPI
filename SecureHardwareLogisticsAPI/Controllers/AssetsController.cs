using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using SecureHardwareLogisticsAPI.DTOs.Requests;
using SecureHardwareLogisticsAPI.Services;

namespace SecureHardwareLogisticsAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AssetsController : ControllerBase
{
    private readonly IAssetService _assetService;
    public AssetsController(IAssetService assetService)
    {
        _assetService = assetService;
    }
    // Method to add a HardwareAsset into inventory
    [HttpPost]
    public async Task<IActionResult> ProvisionAsset([FromBody] ProvisionAssetDto request)
    {
        if (string.IsNullOrWhiteSpace(request.DeviceModel))
        {
            return BadRequest("DeviceModel is required.");
        }

        var result = await _assetService.ProvisionAssetAsync(request);

        return Created($"/api/v1/assets/{result.Id}", result);
    }
    // Method to assign an AssignedMilitaryId to a HardwareAsset
    [HttpPut("{id}/assign")]
    public async Task<IActionResult> AssignAsset(int id, [FromBody] AssignAssetDto request)
    {
        if (string.IsNullOrWhiteSpace(request.AssignedMilitaryId))
        {
            return BadRequest("AssignedMilitaryId is required.");
        }

        var result = await _assetService.AssignAssetAsync(id, request);
        
        if (result == null)
        {
            return NotFound($"Hardware asset with ID {id} was not found.");
        }

        return Ok(result);
    }
    // Method to get all HardwareAsset items
    [HttpGet]
    public async Task<IActionResult> GetAssets()
    {
        var assets = await _assetService.GetAssetsAsync();
        return Ok(assets);
    }
    // Method to get a specific HardwareAsset item and full audit history
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsset(int id)
    {
        var asset = await _assetService.GetAssetAsync(id);
        var logs = await _assetService.GetLogHistoryAsync(id);

        return Ok(new
        {
            Asset = asset,
            Logs = logs
        });
    }
    // Method to submit a MaintenanceRequest for an existing HardwareAsset item
    [HttpPost("/maintenancerequests")]
    public async Task<IActionResult> CreateMaintenanceRequest([FromBody] MaintenanceRequestDto request)
    {
        return BadRequest();
    }
}
using Microsoft.AspNetCore.Mvc;
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
}
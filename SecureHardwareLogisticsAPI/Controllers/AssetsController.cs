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
}
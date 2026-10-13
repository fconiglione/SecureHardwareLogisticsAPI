using Microsoft.AspNetCore.Mvc;
using SecureHardwareLogisticsAPI.Services;

namespace SecureHardwareLogisticsAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class WarrantiesController: ControllerBase
{
    private readonly IExternalSupplierService _externalSupplierService;
    
    public WarrantiesController(IExternalSupplierService externalSupplierService)
    {
        _externalSupplierService = externalSupplierService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWarrantiesAsync(int id)
    {
        var result = await _externalSupplierService.GetWarrantyStatusAsync(id);
        
        return Ok(result);
    }
}
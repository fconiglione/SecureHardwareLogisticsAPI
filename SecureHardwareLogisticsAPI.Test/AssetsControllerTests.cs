using Microsoft.AspNetCore.Mvc;
using Moq;
using SecureHardwareLogisticsAPI.Controllers;
using SecureHardwareLogisticsAPI.DTOs.Responses;
using SecureHardwareLogisticsAPI.Services;

namespace SecureHardwareLogisticsAPI.Test;

public class AssetsControllerTests
{
    [Fact]
    public async Task GetAsset_ReturnsOk_WhenAssetExists()
    {
        
        var mockService = new Mock<IAssetService>();
        
        var fakeAsset = new AssetSummaryDto { Id = 1, SerialNumber = "SN-12345" };
        var fakeLogs = new List<AssetDetailDto>(); 

        mockService.Setup(service => service.GetAssetAsync(1)).ReturnsAsync(fakeAsset);
        mockService.Setup(service => service.GetLogHistoryAsync(1)).ReturnsAsync(fakeLogs);

        var controller = new AssetsController(mockService.Object);
        
        var result = await controller.GetAsset(1);
        
        var okResult = Assert.IsType<OkObjectResult>(result);
        
        Assert.NotNull(okResult.Value);
    }
}
using SecureHardwareLogisticsAPI.DTOs.External;
using SecureHardwareLogisticsAPI.DTOs.Responses;

namespace SecureHardwareLogisticsAPI.Services;

public class ExternalSupplierService: IExternalSupplierService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ExternalSupplierService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<WarrantyStatusDto?> GetWarrantyStatusAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/todos/{id}");

        response.EnsureSuccessStatusCode();
        
        SupplierWarrantyResponse? externalData = await response.Content.ReadFromJsonAsync<SupplierWarrantyResponse>();
        
        var result = new WarrantyStatusDto
        {
            AssetId = externalData.Id,
            WarrantyPlan = externalData.Title,
            IsActive = externalData.Completed,
            CheckedAt = DateTime.UtcNow
        };

        return result;
    }
}
using SecureHardwareLogisticsAPI.DTOs.Responses;

namespace SecureHardwareLogisticsAPI.Services;

public interface IExternalSupplierService
{
    Task<WarrantyStatusDto?> GetWarrantyStatusAsync(int id);
}
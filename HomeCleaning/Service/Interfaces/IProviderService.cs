using HomeCleaning.Domain.Entities;

namespace HomeCleaning.Service.Interfaces;

public interface IProviderService
{
    public Task<bool> AddProviderAsync(Provider provider);
    public Task<bool> UpdateProviderAsync(Provider provider);
    public Task<bool> DeleteByIdAsync(int id);
    public Task<Provider> GetByIdAsync(int id);
    public Task<IEnumerable<Provider>> GetAllAsync();
}

using HomeCleaning.Domain.Entities;

namespace HomeCleaning.Service.Interfaces;

public interface IUserServiceNT
{
    public Task<bool> AddServiceAsync(ServiceNT service);
    public Task<bool> UpdateServiceAsync(ServiceNT service);
    public Task<bool> DeleteByIdAsync(int id);
    public Task<ServiceNT> GetByIdAsync(int id);
    public Task<IEnumerable<ServiceNT>> GetAllAsync();

}

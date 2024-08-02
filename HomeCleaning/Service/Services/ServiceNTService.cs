using HomeCleaning.Data.IRepositories;
using HomeCleaning.Domain.Entities;
using HomeCleaning.Service.Interfaces;
using HomeCleaning.Service.Exceptions;
using HomeCleaning.Data.Repositories;

namespace HomeCleaning.Service.Services;

public class ServiceNTService : IUserServiceNT
{
    IRepository<ServiceNT> userServiceRepository = new Repository<ServiceNT>();
    public async Task<bool> AddServiceAsync(ServiceNT service)
    {
        var services = await this.userServiceRepository.RetrievAllAsync();
        if(services.Any(i => i.Name.Equals( service.Name,StringComparison.OrdinalIgnoreCase)))    
            throw new CustomException(409, "Service already exists");

        await this.userServiceRepository.InsertAsync(service);
        return true;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var deleteResponse = await this.userServiceRepository.DeleteByIdAsync(id);
        if(deleteResponse)
            return true;
        throw new CustomException(404, "Service not found");
        
    }

    

    public async Task<IEnumerable<ServiceNT>> GetAllAsync()
    {
        var services = await this.userServiceRepository.RetrievAllAsync();
        if (services is null)
            throw new CustomException(404, "Service not found");
        return services;
    }

    public async Task<ServiceNT> GetByIdAsync(int id)
    {
        var service = await this.userServiceRepository.RetrievByIdAsync(id);
        if (service is null)
            throw new CustomException(404, "Service not found");
        return service;
    }

    public async Task<bool> UpdateServiceAsync(ServiceNT service)
    {
        var serviceUpd = await this.userServiceRepository.RetrievByIdAsync(service.Id);
        if (serviceUpd is null)
            throw new CustomException(404, "Service not found");
        await this.userServiceRepository.UpdateAsync(service);
        return true;
    }
}

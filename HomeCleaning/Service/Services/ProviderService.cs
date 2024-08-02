using HomeCleaning.Data.IRepositories;
using HomeCleaning.Data.Repositories;
using HomeCleaning.Domain.Entities;
using HomeCleaning.Service.Exceptions;
using HomeCleaning.Service.Interfaces;
using System.Net.Http.Headers;

namespace HomeCleaning.Service.Services;

public class ProviderService : IProviderService
{
    IRepository<Provider> providerRepository = new Repository<Provider>();
    public async Task<bool> AddProviderAsync(Provider provider)
    {
        var providers = await this.providerRepository.RetrievAllAsync();
        if (providers.Any(p => p.Name.Equals(provider.Name, StringComparison.OrdinalIgnoreCase)))
            throw new CustomException(409, "Provider already exists");
        await this.providerRepository.InsertAsync(provider);
        return true;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var deleteResponse = await this.providerRepository.DeleteByIdAsync(id);
        if (deleteResponse)
            return true;
        throw new CustomException(404, "Provider not found");
    }

    public async Task<IEnumerable<Provider>> GetAllAsync()
    {
        var providers = await this.providerRepository.RetrievAllAsync();
        if (providers is null)
            throw new CustomException(404, "Service not found");
        return providers;
    }

    public async Task<Provider> GetByIdAsync(int id)
    {
        var provider = await this.providerRepository.RetrievByIdAsync(id);
        if (provider is null)
            throw new CustomException(404, "User not found");
        return provider;
    }

    public async Task<bool> UpdateProviderAsync(Provider provider)
    {
        var providerUpd = await this.providerRepository.RetrievByIdAsync(provider.Id);
        if (providerUpd is null)
            throw new CustomException(404, "Service not found");
        await this.UpdateProviderAsync(provider);
        return true;
    }
}

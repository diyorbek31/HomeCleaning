using HomeCleaning.Data.IRepositories;
using HomeCleaning.Domain.Commons;
using HomeCleaning.Domain.Configurations;
using HomeCleaning.Domain.Entities;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.CompilerServices;

namespace HomeCleaning.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    public List<TEntity> entities;
    public string path = "";
    public  Repository()
    {
        entities = new List<TEntity>();
        var entityName = typeof(TEntity).Name;
        switch (entityName)
        {
            case nameof(User):
                path = Database.USER_PATH;
                break;
            case nameof(Provider):
                path = Database.PROVIDER_PATH;
                break;
            case nameof(ServiceNT):
                path = Database.SERVICENT_PATH;
                break;
            case nameof(Booking):
                path = Database.BOOKING_PATH;
                break;
            default:
                throw new NotSupportedException($"Entity type {entityName} is not supported.");

        }

    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        List<TEntity> infos = new List<TEntity>();
        bool IsAvaible = false;
        var entities = await this.RetrievAllAsync();
        await File.WriteAllTextAsync(path, "");

        IsAvaible = entities.Any(e => e.Id == id);
        infos.AddRange(entities.Where(e => e.Id != id));

        var str = JsonConvert.SerializeObject(infos, Formatting.Indented);
        await File.AppendAllTextAsync(path, str);
        return IsAvaible;
    }

    public async Task<bool> InsertAsync(TEntity entity)
    {
        entity.Id = await GenerateIdAsync();
        var entities = await this.RetrievAllAsync();
        entities.Add(entity);
        var str = JsonConvert.SerializeObject(entities, Formatting.Indented);
        await File.WriteAllTextAsync(path, str);
        return true;
    }

    public async Task<List<TEntity>> RetrievAllAsync()
    {
        string models = await File.ReadAllTextAsync(path);
        if (string.IsNullOrEmpty(models))
            models = "[]";
        var results = JsonConvert.DeserializeObject<List<TEntity>>(models);
        return results;
    }

    public async Task<TEntity> RetrievByIdAsync(int id)
    {
        var entities = await RetrievAllAsync();
        return entities.FirstOrDefault(e => e.Id == id);
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        bool IsAvailable = false;
        var entities = await this.RetrievAllAsync();
        await File.WriteAllTextAsync(path, "[]");
        await this.DeleteByIdAsync(entity.Id);
        entities.Add(entity);

        var str = JsonConvert.SerializeObject(entities, Formatting.Indented);
        await File.WriteAllTextAsync(path, str);
        return IsAvailable;
    }

    private async Task<int> GenerateIdAsync()
    {
        var items = await RetrievAllAsync();
        if (items.Count() == 0)
            return 1;
        var lastId = items.Max(i => i.Id);
        return ++lastId;    
    } 

    

}

namespace HomeCleaning.Data.IRepositories;

public interface IRepository<TEntity>
{
    public Task<bool> InsertAsync(TEntity entity);
    public Task<bool> UpdateAsync(TEntity entity);
    public Task<bool> DeleteByIdAsync(int id);
    public Task<TEntity> RetrievByIdAsync(int id);
    public Task<List<TEntity>> RetrievAllAsync();
}

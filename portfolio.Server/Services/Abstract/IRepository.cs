namespace portfolio.Server.Services.Abstract
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAsync();
        Task<T> GetAsync(Guid id);
        Task CreateAsync(T newItem);
        Task UpdateAsync(Guid id, T updateItem);
        Task RemoveAsync(Guid id);
    }
}

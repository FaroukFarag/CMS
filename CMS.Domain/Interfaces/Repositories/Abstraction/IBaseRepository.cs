namespace CMS.Domain.Interfaces.Repositories.Abstraction;

public interface IBaseRepository<T>
{
    Task<T> CreateAsync(T entity);
    Task<T> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    T Update(T newEntity);
    T Delete(int id);
}

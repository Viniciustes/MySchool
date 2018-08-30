using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Domain.Interfaces.Repositories
{
    public interface IRepository<Entity> where Entity : class
    {
        IEnumerable<Entity> GettAll();
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsNoTrackingAsync(int id);
        Task<Entity> GetByIdAsync(int id);
        Task AddAsync(Entity entity);
        Task UpdateAsync(Entity entity);
        Task DeleteAsync(Entity entity);
        Task<int> CountAsync(Entity entity);
        IQueryable<Entity> GetAllIQuerableAsNoTracking();
        Task SaveChangesAsync();
    }
}
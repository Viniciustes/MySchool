using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Service.Interfaces
{
    public interface IService<Entity> where Entity : class
    {
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsNoTrackingAsync(int id);
        Task<Entity> GetByIdAsync(int id);
        Task AddAsync(Entity entity);
        Task UpdateAsync(Entity entity);
        Task DeleteAsync(Entity entity);
    }
}

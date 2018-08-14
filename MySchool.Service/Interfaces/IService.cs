using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Service.Interfaces
{
    public interface IService<Entity> where Entity : class
    {
        Task<IEnumerable<Entity>> GetAllAsync();
    }
}

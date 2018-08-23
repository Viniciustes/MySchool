using System.Collections.Generic;
using System.Threading.Tasks;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Service.Interfaces;

namespace MySchool.Service.Services
{
    public class Service<Entity> : IService<Entity> where Entity : class
    {
        protected readonly IRepository<Entity> _repository;

        public Service(IRepository<Entity> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Entity entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Entity entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Entity> GetByIdAsNoTrackingAsync(int id)
        {
            return await _repository.GetByIdAsNoTrackingAsync(id);
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Entity entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task<int> CountAsync(Entity entity)
        {
            return await _repository.CountAsync(entity);
        }
    }
}
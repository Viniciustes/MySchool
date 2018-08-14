using System.Collections.Generic;
using System.Threading.Tasks;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Service.Interfaces;

namespace MySchool.Service.Services
{
    public class Service<Entity> : IService<Entity> where Entity : class
    {
        private readonly IRepository<Entity> _repository;

        public Service(IRepository<Entity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}

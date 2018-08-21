using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Infrastructure.Contexts;

namespace MySchool.Infrastructure.Repositories
{
    public class Repository<Entity> : IRepository<Entity> where Entity : BasicEntity
    {
        protected readonly MySchoolContext _context;

        public Repository(MySchoolContext mySchoolContext)
        {
            _context = mySchoolContext;
        }

        public async Task AddAsync(Entity entity)
        {
            await _context.Set<Entity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _context.Set<Entity>().AsNoTracking().ToListAsync();
        }

        public async Task<Entity> GetByIdAsNoTrackingAsync(int id)
        {
            return await
                _context.Set<Entity>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            return await
              _context.Set<Entity>()
              .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Entity entity)
        {
            _context.Set<Entity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
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

            //SET NOCOUNT ON;
            //INSERT INTO [Student] ([EnrollmentDate], [FirstName], [LastName])
            //VALUES (@p0, @p1, @p2);
            //SELECT [Id]
            //FROM [Student]
            //WHERE @@ROWCOUNT = 1 AND [Id] = scope_identity();
        }

        public async Task DeleteAsync(Entity entity)
        {
            _context.Set<Entity>().Remove(entity);
            await _context.SaveChangesAsync();

            //SET NOCOUNT ON;
            //DELETE FROM [Student]
            //WHERE [Id] = @p0;
            //SELECT @@ROWCOUNT;
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

            //SET NOCOUNT ON;
            //UPDATE [Student] SET [EnrollmentDate] = @p0, [FirstName] = @p1, [LastName] = @p2
            //WHERE [Id] = @p3;
            //SELECT @@ROWCOUNT;
        }

        public async Task<int> CountAsync(Entity entity)
        {
            return await _context.Set<Entity>().CountAsync();
        }

        public IQueryable<Entity> GetAllIQuerableAsNoTracking()
        {
            var entities = from d in _context.Set<Entity>()
                           select d;

            return entities.AsNoTracking();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Entity> GettAll()
        {
            return _context.Set<Entity>();
        }
    }
}

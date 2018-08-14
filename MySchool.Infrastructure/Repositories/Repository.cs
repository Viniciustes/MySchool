using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Infrastructure.Contexts;

namespace MySchool.Infrastructure.Repositories
{
    public class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        private readonly MySchoolContext _context;

        public Repository(MySchoolContext mySchoolContext)
        {
            _context = mySchoolContext;
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _context.Set<Entity>().AsNoTracking().ToListAsync();
        }
    }
}

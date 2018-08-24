using Microsoft.EntityFrameworkCore;
using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Infrastructure.Repositories
{
    public class RepositoryCourse : Repository<Course>, IRepositoryCourse
    {
        public RepositoryCourse(MySchoolContext context) : base(context) { }

        public new async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.Include(x => x.Department).AsNoTracking().ToListAsync();
        }
    }
}

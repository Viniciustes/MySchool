using Microsoft.EntityFrameworkCore;
using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Infrastructure.Repositories
{
    public class RepositoryDepartment : Repository<Department>, IRepositoryDepartment
    {
        public RepositoryDepartment(MySchoolContext mySchoolContext) : base(mySchoolContext)
        {
        }

        public new async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _context.Departments
                .Include(x => x.Administrator)
                .Include(x => x.Courses)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

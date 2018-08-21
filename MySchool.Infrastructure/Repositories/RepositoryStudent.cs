using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Infrastructure.Contexts;

namespace MySchool.Infrastructure.Repositories
{
    public class RepositoryStudent : Repository<Student>, IRepositoryStudent
    {
        public RepositoryStudent(MySchoolContext context) : base(context) { }

        public async Task<Student> GetStudentByIdAsNoTrackingAsync(int id)
        {
            return await
                _context.Students
                .Include(e => e.Enrollments)
                    .ThenInclude(c => c.Course)
               .AsNoTracking()
               .SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Infrastructure.Repositories
{
    public class RepositoryInstructor : Repository<Instructor>, IRepositoryInstructor
    {
        public RepositoryInstructor(MySchoolContext context) : base(context) { }

        public new async Task<IEnumerable<Instructor>> GetAllAsync()
        {
            return await _context.Instructors
                .Include(x => x.OfficeAssignment)
                .Include(x => x.CourseAssignments)
                    .ThenInclude(x => x.Course)
                        .ThenInclude(x => x.Enrollments)
                            .ThenInclude(x => x.Student)
                .Include(x => x.CourseAssignments)
                    .ThenInclude(x => x.Course)
                        .ThenInclude(x => x.Department)
                .AsNoTracking()
                .OrderBy(x => x.FirstName)
                .ToListAsync();
        }

        public new async Task<Instructor> GetByIdAsync(int id)
        {
            return await _context.Instructors
                .Include(x => x.OfficeAssignment)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public new async Task<Instructor> GetByIdAsNoTrackingAsync(int id)
        {
            return await _context.Instructors
                .Include(x => x.OfficeAssignment)
                .Include(x => x.CourseAssignments)
                    .ThenInclude(x => x.Course)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
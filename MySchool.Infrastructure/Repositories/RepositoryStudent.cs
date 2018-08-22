using System.Collections.Generic;
using System.Linq;
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

        public async Task<IList<Student>> GetStudentListAsNoTrackingAsyncPaginated(string sortOrder, string searchString)
        {
            var students = from s in _context.Students
                           select s;

            if (!string.IsNullOrEmpty(searchString))
                students = students.Where(x => x.FirstName.ToLower().Contains(searchString.ToLower()) || x.LastName.ToLower().Contains(searchString.ToLower()));

            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }
            return await students.AsNoTracking().ToListAsync();
        }
    }
}
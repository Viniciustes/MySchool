using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Infrastructure.Contexts;

namespace MySchool.Infrastructure.Repositories
{
    public class RepositoryCourseAssignment : IRepositoryCourseAssignment
    {
        protected readonly MySchoolContext _context;

        public RepositoryCourseAssignment(MySchoolContext context)
        {
            _context = context;
        }

        public void Delete(CourseAssignment courseAssignment)
        {
            _context.Remove(courseAssignment);
            _context.SaveChanges();
        }
    }
}

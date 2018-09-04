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

        public new async Task<Student> GetByIdAsNoTrackingAsync(int id)
        {
            return await
                _context.Students
                .Include(e => e.Enrollments)
                    .ThenInclude(c => c.Course)
               .AsNoTracking()
               .SingleOrDefaultAsync(s => s.Id == id);

            // Select da consulta abaixo:
            //	SELECT [e.Enrollments].[Id], [e.Enrollments].[CourseId], [e.Enrollments].[Grade], [e.Enrollments].[StudentId], /  [e.Course]./[Id], [e.Course].[Credits], [e.Course].[Title]
            //	FROM [Enrollment] AS [e.Enrollments]
            //	INNER JOIN [Course] AS [e.Course] ON [e.Enrollments].[CourseId] = [e.Course].[Id]
            //	INNER JOIN (
            //	    SELECT TOP(1) [e0].[Id]
            //	    FROM [Student] AS [e0]
            //	    WHERE [e0].[Id] = 1
            //	    ORDER BY [e0].[Id]
            //	) AS [t] ON [e.Enrollments].[StudentId] = [t].[Id]
            //	ORDER BY [t].[Id]
        }
    }
}
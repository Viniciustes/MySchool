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


        // Esse método faz o carregamento adiantado, "Eager Loading", de todas as informações
        // em um uníco acesso ao banco de dados.
        //public new async Task<IEnumerable<Instructor>> GetAllAsync()
        //{
        //    return await _context.Instructors
        //        .Include(x => x.OfficeAssignment)
        //        .Include(x => x.CourseAssignments)
        //            .ThenInclude(x => x.Course)
        //                .ThenInclude(x => x.Enrollments)
        //                    .ThenInclude(x => x.Student)
        //        .Include(x => x.CourseAssignments)
        //            .ThenInclude(x => x.Course)
        //                .ThenInclude(x => x.Department)
        //        .AsNoTracking()
        //        .OrderBy(x => x.FirstName)
        //        .ToListAsync();
        //}


        //  Esse método traz o carregamente explicíto, "Explict Loading", das informações mais importantes
        //  que vão ser exibidas na tela inicial, as demais informações, serão buscada no banco de dados novamente
        //  quando solicitado novamente.
        public new async Task<IEnumerable<Instructor>> GetAllAsync()
        {
            return await _context.Instructors
                    .Include(i => i.OfficeAssignment)
                    .Include(i => i.CourseAssignments)
                        .ThenInclude(i => i.Course)
                        .ThenInclude(i => i.Department)
                    .AsNoTracking()
                    .OrderBy(i => i.LastName)
                    .ToListAsync();
        }

        public async Task GetCourse(Course course)
        {
             await _context.Entry(course).Collection(x => x.Enrollments).LoadAsync();
        }

        public async Task GetEnrollment(Enrollment enrollment)
        {
            await _context.Entry(enrollment).Reference(x => x.Student).LoadAsync();
        }
    }
}
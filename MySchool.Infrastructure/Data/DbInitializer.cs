using MySchool.Domain.Entities;
using MySchool.Infrastructure.Contexts;
using System.Linq;

namespace MySchool.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MySchoolContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any()) return;

            var students = new Student[]
            {
                new Student {FirstName = "Vanessa", LastName = "Pedrosa"},
                new Student {FirstName = "Larissa", LastName = "Silva"},
                new Student {FirstName = "Ana Paula", LastName = "Palumbo"},
                new Student {FirstName = "Gabriela", LastName = "Queiroz"},
                new Student {FirstName = "Maria", LastName = "Sebastiana"}
            };

            foreach (var student in students)
            {
                context.Students.Add(student);
            }
            context.SaveChanges();
        }
    }
}

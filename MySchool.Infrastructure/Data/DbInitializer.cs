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

            var students = new Student[] {
                   new Student("Vanessa", "Pedrosa"),
                   new Student("Larissa", "Silva"),
                   new Student("Ana Paula", "Palumbo"),
                   new Student("Gabriela", "Queiroz"),
                   new Student("Maria", "Sebastiana")
             };
            context.Students.AddRange(students);
            context.SaveChanges();

            var courses = new Course[] {
                  new Course {
                    Credits = 45, Title = "Arquitetura"
                  },
                  new Course {
                    Credits = 1, Title = "Lógica de Programação"
                  },
                  new Course {
                    Credits = 5, Title = "Banco de Dados"
                  },
                  new Course {
                    Credits = 6, Title = "HTML 5"
                  },
                  new Course {
                    Credits = 7, Title = "Bootstrap"
                  },
                  new Course {
                    Credits = 3, Title = "Java básico"
                  }
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();

            var enrollments = new Enrollment[] {
                  new Enrollment {
                    StudentId = 1, CourseId = 1, Grade = Domain.Enums.Grade.B
                  },
                  new Enrollment {
                    StudentId = 2, CourseId = 1
                  },
                  new Enrollment {
                    StudentId = 3, CourseId = 2, Grade = Domain.Enums.Grade.A
                  },
                  new Enrollment {
                    StudentId = 4, CourseId = 4
                  },
                  new Enrollment {
                    StudentId = 5, CourseId = 5, Grade = Domain.Enums.Grade.C
                  },
                  new Enrollment {
                    StudentId = 2, CourseId = 1, Grade = Domain.Enums.Grade.F
                  }
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}
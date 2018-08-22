using MySchool.Domain.Entities;
using MySchool.Infrastructure.Contexts;
using System;
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
                   new Student {
                        FirstName = "Vanessa", LastName = "Pedrosa", EnrollmentDate = DateTime.Parse("2002-09-30")
                   },
                   new Student {
                        FirstName = "Larissa", LastName = "Silva", EnrollmentDate = DateTime.Parse("2003-02-24")
                   },
                   new Student {
                        FirstName = "Ana Paula", LastName = "Palumbo", EnrollmentDate = DateTime.Parse("2004-07-12")
                   },
                   new Student {
                        FirstName = "Gabriela", LastName = "Queiroz", EnrollmentDate = DateTime.Parse("2005-04-15")
                   },
                   new Student {
                        FirstName = "Maria", LastName = "Sebastiana", EnrollmentDate = DateTime.Parse("2006-06-11")
                   }
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
using MySchool.Domain.Enums;
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
                   new Student("Vanessa", "Pedrosa"),
                   new Student("Larissa", "Silva"),
                   new Student("Ana Paula", "Palumbo"),
                   new Student("Gabriela", "Queiroz"),
                   new Student("Maria", "Sebastiana")
             };
            context.Students.AddRange(students);
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor("Paulo","Bareto",DateTime.Parse("2018-04-22")),
                new Instructor("João","Alcedo",DateTime.Parse("2017-03-15")),
                new Instructor("Leticia","Augusta",DateTime.Parse("2016-05-18")),
                new Instructor("Jorge","Aragão",DateTime.Parse("2015-07-17")),
                new Instructor("Roberto","Carlos",DateTime.Parse("2014-01-07"))
            };
            context.Instructors.AddRange(instructors);
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department("Financeiro", 150, DateTime.Parse("2015-06-07"), instructors.Single(x => x.FirstName == "João").Id),
                new Department("RH", 256, DateTime.Parse("2016-07-17"), instructors.Single(x => x.FirstName == "Leticia").Id),
                new Department("Gerência", 380, DateTime.Parse("2017-08-27"), instructors.Single(x => x.FirstName == "Roberto").Id),
                new Department("Informática", 580, DateTime.Parse("2018-08-24"), instructors.Single(x => x.FirstName == "Jorge").Id)
            };
            context.Departments.AddRange(departments);
            context.SaveChanges();

            var courses = new Course[]
            {
                 new Course("Credito", 65, departments.Single(x=> x.Name =="Financeiro").Id),
                 new Course("Contratação", 156, departments.Single(x=> x.Name =="RH").Id),
                 new Course("Banco de dados", 757, departments.Single(x=> x.Name =="Informática").Id),
                 new Course("Contas", 1, departments.Single(x=> x.Name =="Financeiro").Id),
                 new Course("Controle de Caixa", 4445, departments.Single(x=> x.Name =="Gerência").Id),
                 new Course("Java", 1578, departments.Single(x=> x.Name =="Informática").Id),
                 new Course("Fluxo de Caixa", 3255, departments.Single(x=> x.Name =="Gerência").Id)
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment(instructors.Single(x=> x.FirstName == "Paulo").Id, "Taguatinga"),
                new OfficeAssignment(instructors.Single(x=> x.FirstName == "Leticia").Id, "Brasília"),
                new OfficeAssignment(instructors.Single(x=> x.FirstName == "Roberto").Id, "Sobradinho")
            };
            context.OfficeAssignments.AddRange(officeAssignments);
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment(courses.Single(x=> x.Title == "Credito").Id, instructors.Single(x=>x.FirstName == "Paulo").Id),
                new CourseAssignment(courses.Single(x=> x.Title == "Credito").Id, instructors.Single(x=>x.FirstName == "João").Id),
                new CourseAssignment(courses.Single(x=> x.Title == "Contratação").Id, instructors.Single(x=>x.FirstName == "Paulo").Id),
                new CourseAssignment(courses.Single(x=> x.Title == "Java").Id, instructors.Single(x=>x.FirstName == "Leticia").Id),
                new CourseAssignment(courses.Single(x=> x.Title == "Banco de dados").Id, instructors.Single(x=>x.FirstName == "Leticia").Id),
                new CourseAssignment(courses.Single(x=> x.Title == "Fluxo de Caixa").Id, instructors.Single(x=>x.FirstName == "João").Id),
                new CourseAssignment(courses.Single(x=> x.Title == "Java").Id, instructors.Single(x=>x.FirstName == "Paulo").Id),
                new CourseAssignment(courses.Single(x=> x.Title == "Contas").Id, instructors.Single(x=>x.FirstName == "Leticia").Id),
                new CourseAssignment(courses.Single(x=> x.Title == "Contratação").Id, instructors.Single(x=>x.FirstName == "Jorge").Id),
                new CourseAssignment(courses.Single(x=> x.Title == "Contas").Id, instructors.Single(x=>x.FirstName == "Jorge").Id),
                new CourseAssignment(courses.Single(x=> x.Title == "Controle de Caixa").Id, instructors.Single(x=>x.FirstName == "Roberto").Id),
                new CourseAssignment(courses.Single(x=> x.Title == "Fluxo de Caixa").Id, instructors.Single(x=>x.FirstName == "Roberto").Id),
                new CourseAssignment(courses.Single(x=> x.Title == "Controle de Caixa").Id, instructors.Single(x=>x.FirstName == "João").Id),
                new CourseAssignment(courses.Single(x=> x.Title == "Fluxo de Caixa").Id, instructors.Single(x=>x.FirstName == "Jorge").Id)
            };
            context.CourseAssignments.AddRange(courseInstructors);
            context.SaveChanges();

            var enrollments = new Enrollment[] {
                new Enrollment(students.Single(x=> x.FirstName == "Vanessa").Id, courses.Single(x=> x.Title == "Java").Id, Grade.C),
                new Enrollment(students.Single(x=> x.FirstName == "Ana Paula").Id, courses.Single(x=> x.Title == "Contratação").Id),
                new Enrollment(students.Single(x=> x.FirstName == "Larissa").Id, courses.Single(x=> x.Title == "Java").Id, Grade.A),
                new Enrollment(students.Single(x=> x.FirstName == "Vanessa").Id, courses.Single(x=> x.Title == "Contratação").Id),
                new Enrollment(students.Single(x=> x.FirstName == "Larissa").Id, courses.Single(x=> x.Title == "Credito").Id, Grade.B),
                new Enrollment(students.Single(x=> x.FirstName == "Ana Paula").Id, courses.Single(x=> x.Title == "Java").Id),
                new Enrollment(students.Single(x=> x.FirstName == "Gabriela").Id, courses.Single(x=> x.Title == "Contratação").Id, Grade.B),
                new Enrollment(students.Single(x=> x.FirstName == "Vanessa").Id, courses.Single(x=> x.Title == "Credito").Id),
                new Enrollment(students.Single(x=> x.FirstName == "Ana Paula").Id, courses.Single(x=> x.Title == "Banco de dados").Id, Grade.E),
                new Enrollment(students.Single(x=> x.FirstName == "Gabriela").Id, courses.Single(x=> x.Title == "Controle de Caixa").Id),
                new Enrollment(students.Single(x=> x.FirstName == "Larissa").Id, courses.Single(x=> x.Title == "Controle de Caixa").Id, Grade.F),
                new Enrollment(students.Single(x=> x.FirstName == "Gabriela").Id, courses.Single(x=> x.Title == "Banco de dados").Id, Grade.C)
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySchool.Service.Interfaces;
using MySchool.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceInstructor _serviceInstructor;

        public InstructorsController(IMapper mapper, IServiceInstructor serviceInstructor)
        {
            _mapper = mapper;
            _serviceInstructor = serviceInstructor;
        }

        public async Task<IActionResult> Index(int? id, int? courseId)
        {
            var instructors = await _serviceInstructor.GetAllAsync();

            var instructorsViewModel = _mapper.Map<IEnumerable<InstructorViewModel>>(instructors);

            var instructorIndexDataViewModel = new InstructorIndexDataViewModel
            {
                InstructorsViewModel = instructorsViewModel
            };

            if (id != null)
            {
                ViewData["InstructorId"] = id.Value;

                var instructor = instructorIndexDataViewModel.InstructorsViewModel.Single(x => x.Id == id.Value);

                instructorIndexDataViewModel.CoursesViewModel = instructor.CourseAssignments.Select(x => x.Course);
            }

            //// Carregamento adiantado
            //if (courseId != null)
            //{
            //    ViewData["CourseId"] = courseId.Value;

            //    instructorIndexDataViewModel.EnrollmentsViewModel = instructorIndexDataViewModel.CoursesViewModel.Where(x => x.Id == courseId.Value).Single().Enrollments;
            //}

            // Carregamento explícito
            // Vai várias vezes no banco de dados no foreach
            // Pouca performace
            if (courseId != null)
            {
                ViewData["CourseId"] = courseId.Value;

                var selectedCourse = instructorIndexDataViewModel.CoursesViewModel.Single(x => x.Id == courseId);

                await _serviceInstructor.GetCourse(selectedCourse);
                foreach (var enrollment in selectedCourse.Enrollments)
                {
                    await _serviceInstructor.GetEnrollment(enrollment);
                }

                instructorIndexDataViewModel.EnrollmentsViewModel = selectedCourse.Enrollments;
            }

            return View(instructorIndexDataViewModel);
        }
    }
}
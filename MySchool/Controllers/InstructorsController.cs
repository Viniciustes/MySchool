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

            if (courseId != null)
            {
                ViewData["CourseId"] = courseId.Value;

                instructorIndexDataViewModel.EnrollmentsViewModel = instructorIndexDataViewModel.CoursesViewModel.Where(x => x.Id == courseId.Value).Single().Enrollments;
            }
            return View(instructorIndexDataViewModel);
        }
    }
}
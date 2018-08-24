using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySchool.Service.Interfaces;
using MySchool.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceCourse _serviceCourse;

        public CoursesController(IMapper mapper, IServiceCourse serviceCourse)
        {
            _mapper = mapper;
            _serviceCourse = serviceCourse;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var courses = await _serviceCourse.GetAllAsync();
            var coursesViewModel = _mapper.Map<IEnumerable<CourseViewModel>>(courses);

            return View(PaginatedListViewModel<CourseViewModel>.CreateAsync(coursesViewModel, page ?? 1));
        }
    }
}
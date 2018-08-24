using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySchool.Service.Interfaces;
using MySchool.ViewModels;
using System.Collections.Generic;
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

        public async Task<IActionResult> Index()
        {
            var instructorIndex = await _serviceInstructor.GetAllAsync();

            var vwm = _mapper.Map<IEnumerable<InstructorIndexDataViewModel>>(instructorIndex);

            return View(instructorIndex);
        }
    }
}
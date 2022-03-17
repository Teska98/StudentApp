using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using StudentApp.Models.Responses;
using StudentApp.WebAPI.Repositories;
using System.Collections.Generic;

namespace StudentApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPost]
        public ActionResult<Course> Create(Course course)
        {
            var model = _courseRepository.Create(course);
            return Ok(model);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            var courses = _courseRepository.Get();
            return Ok(courses);
        }

        [HttpGet("courseId")]
        public ActionResult<IEnumerable<CourseDetails>> GetCourseDetails(int courseId)
        {
            var courseDetails = _courseRepository.GetCourseDetails(courseId);
            return Ok(courseDetails);
        }
    }
}

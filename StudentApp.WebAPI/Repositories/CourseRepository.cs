using Microsoft.EntityFrameworkCore;
using StudentApp.Models;
using StudentApp.Models.Responses;
using StudentApp.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace StudentApp.WebAPI.Repositories
{
    public interface ICourseRepository
    {
        Course Create(Course course);
        IEnumerable<Course> Get();
        IEnumerable<CourseDetails> GetCourseDetails(int courseId);
    }

    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CourseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Course Create(Course course)
        {
            var entity = _dbContext.Courses.Add(course).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public IEnumerable<Course> Get()
        {
            return _dbContext.Courses.AsEnumerable();
        }

        public IEnumerable<CourseDetails> GetCourseDetails(int courseId)
        {
            var course = _dbContext.StudentCourses.Where(x => x.CourseId == courseId)
                .Include(x => x.Course).Include(x => x.Student)
                .Select(x => new CourseDetails
                {
                    CourseId = courseId,
                    CourseName = x.Course.CourseName,
                    FullName = $"{x.Student.FirstName} {x.Student.LastName}",
                    StudentId = x.StudentId
                }).AsEnumerable();

            return course;
        }
    }
}

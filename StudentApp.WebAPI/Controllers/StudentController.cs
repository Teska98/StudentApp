using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using StudentApp.Models.Requests;
using StudentApp.WebAPI.Repositories;
using System.Collections.Generic;

namespace StudentApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            var students = _studentRepository.Get();
            return Ok(students);
        }

        [HttpPost]
        public ActionResult<Student> Create(StudentDTO student)
        {
            var model = _studentRepository.Create(student);
            return Ok(model);
        }

        [HttpDelete]
        public ActionResult Delete(int studentId)
        {
            var student = _studentRepository.GetById(studentId);

            if (student == null)
                return NotFound();

            _studentRepository.Delete(student);
            return Ok();
        }

        [HttpPut]
        public ActionResult Edit(int studentId, StudentDTO student)
        {
            var studentInDb = _studentRepository.GetById(studentId);

            if (studentInDb == null)
                return NotFound();

            var updatedEntity = new Student
            {
                Id = studentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                IndexNumber = student.IndexNumber,
                StudentStatusId = student.StudentStatusId,
                YearOfStudy = student.YearOfStudy
            };

            _studentRepository.Update(updatedEntity);

            return Ok();
        }

        [HttpGet("statuses")]
        public ActionResult<StudentStatus> GetStudentStatuses()
        {
            var studentStatuses = _studentRepository.GetStudentStatuses();
            return Ok(studentStatuses);
        }
    }
}

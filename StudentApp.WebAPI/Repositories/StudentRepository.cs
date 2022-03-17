using Microsoft.EntityFrameworkCore;
using StudentApp.Models;
using StudentApp.Models.Requests;
using StudentApp.Models.Responses;
using StudentApp.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace StudentApp.WebAPI.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> Get();
        Student Create(StudentDTO student);
        void Delete(Student student);
        Student GetById(int studentId);
        void Update(Student student);
        IEnumerable<StudentStatus> GetStudentStatuses();
        StudentDetails GetStudentDetails(int studentId);
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student Create(StudentDTO studentDTO)
        {
            var studentModel = new Student
            {
                FirstName = studentDTO.FirstName,
                IndexNumber = studentDTO.IndexNumber,
                LastName = studentDTO.LastName,
                StudentStatusId = studentDTO.StudentStatusId,
                YearOfStudy = studentDTO.YearOfStudy
            };

            var entity = _dbContext.Students.Add(studentModel).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(Student student)
        {
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Student> Get()
        {
            return _dbContext.Students.FromSqlRaw("GetStudentsProcedure");
        }

        public Student GetById(int studentId)
        {
            return _dbContext.Students.AsNoTracking().FirstOrDefault(x => x.Id == studentId);
        }

        public StudentDetails GetStudentDetails(int studentId)
        {
            var studentDetails = _dbContext.StudentCourses.Include(x=>x.Student).Include(x => x.Course)
                .Select(x=> new StudentDetails)
        }

        public IEnumerable<StudentStatus> GetStudentStatuses()
        {
            return _dbContext.StudentStatuses.AsEnumerable();
        }

        public void Update(Student student)
        {
            _dbContext.Attach(student).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}

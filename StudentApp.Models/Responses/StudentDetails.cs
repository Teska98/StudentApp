using System.Collections.Generic;

namespace StudentApp.Models.Responses
{
    public class StudentDetails
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public List<string> Courses { get; set; }
    }
}

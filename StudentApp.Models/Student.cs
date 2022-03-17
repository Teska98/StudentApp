using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApp.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfStudy { get; set; }

        [ForeignKey(nameof(StudentStatusId))]
        public virtual StudentStatus StudentStatus { get; set; }
        public int StudentStatusId { get; set; }
    }
}

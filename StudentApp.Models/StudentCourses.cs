using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApp.Models
{
    public class StudentCourses
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }
        public int StudentId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }
        public int CourseId { get; set; }
    }
}

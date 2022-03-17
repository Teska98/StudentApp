using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class StudentStatus
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; }
    }
}

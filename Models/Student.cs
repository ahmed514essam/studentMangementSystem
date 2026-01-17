using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace studentMangementSystem.Models
{
    [Table("Student")]
    public class Student
    {

        //Essential Property

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public string PasswordHash { get; set; } 

        public DateTime InrollDate { get; set; } = DateTime.UtcNow;

        public int DeliveryOrder { get; set; }

        //Relationships

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int StudyYearId { get; set; }
        public StudyYear StudyYear { get; set; }

        public string Role { get; set; } = "Student";
        [NotMapped]
        public string Password { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }

        public int SportId { get; set; }
        public Sport Sport { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}


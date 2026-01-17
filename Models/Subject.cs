using System.ComponentModel.DataAnnotations.Schema;

namespace studentMangementSystem.Models
{
    [Table("Subject")]
    public class Subject
    {
        // Essential Property

        public int Id { get; set; }
        public string Name { get; set; }
        public int CreditHours { get; set; }
        public string SubjectDoctor { get; set; }

        public int DeliveryOrder { get; set; }

        // Relationships

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<StudentSubject> StudentSubjects  { get; set; }

        public int StudyYearId { get; set; }
        public  StudyYear StudyYear { get; set; }




    }
}

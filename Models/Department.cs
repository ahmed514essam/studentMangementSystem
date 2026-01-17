using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace studentMangementSystem.Models
{
    [Table("Departments")]
    public class Department
    {
        // Essential Property

        public int Id { get; set; }
        public string Name { get; set; }
        public string DepartmentHead { get; set; }

        public int DeliveryOrder { get; set; }
        // Relationships

        public ICollection<Student> Students { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        //public ICollection<StudyYear> StudyYears { get; set; }

        public ICollection<DepartmentStudyYear> DepartmentStudyYears { get; set; }


    }
}

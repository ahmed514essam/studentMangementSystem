using System.ComponentModel.DataAnnotations;

namespace studentMangementSystem.Models
{
    public class AddStudentVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime InrollDate { get; set; }
        public int DepartmentId { get; set; }
        public int StudyYearId { get; set; }
        public int SportId { get; set; }
        public int StatusId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}

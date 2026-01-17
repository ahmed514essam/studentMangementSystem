namespace studentMangementSystem.Models
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime InrollDate { get; set; }

        // العلاقات كـ مفاتيح فقط
        public int DepartmentId { get; set; }
        public int StudyYearId { get; set; }
        public int SportId { get; set; }
        public int StatusId { get; set; }

        // أسماء العلاقات للعرض فقط
        public string DepartmentName { get; set; }
        public string StudyYearName { get; set; }
        public string SportName { get; set; }
        public string StatusName { get; set; }
    }
}

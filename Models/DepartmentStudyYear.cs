namespace studentMangementSystem.Models
{
    public class DepartmentStudyYear
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int StudyYearId { get; set; }
        public StudyYear StudyYear { get; set; }
    }
}

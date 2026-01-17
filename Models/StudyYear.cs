namespace studentMangementSystem.Models
{
    public class StudyYear
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public ICollection<Student> Students { get; set; }
        public ICollection<Subject> Subjects { get; set; }


        public ICollection<DepartmentStudyYear> DepartmentStudyYears { get; set; }
    }

}

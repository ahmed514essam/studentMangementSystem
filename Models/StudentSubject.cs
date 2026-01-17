namespace studentMangementSystem.Models
{
    public class StudentSubject
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int StudentDtoId { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public decimal TotalMarks { get; set; }
    }
}

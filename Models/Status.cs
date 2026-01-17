namespace studentMangementSystem.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }  // ناجح – راسب – محروم – خريج
        public ICollection<Student> Students { get; set; }

    }

}

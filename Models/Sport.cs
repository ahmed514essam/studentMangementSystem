using System.ComponentModel.DataAnnotations.Schema;

namespace studentMangementSystem.Models
{
    [Table("Sport")]
    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coach { get; set; }
        public int DeliveryOrder { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}

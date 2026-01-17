using System.ComponentModel.DataAnnotations;

namespace studentMangementSystem.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }


        public string RoleName { get; set; }



    }
}

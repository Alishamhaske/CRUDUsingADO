using Microsoft.Build.Framework;

namespace CRUDUsingADO.Models
{
    public class Student
    {
   
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [Required]
        public int Percentage { get; set; }

        [Required]
        public string? City { get; set; }
    }
}

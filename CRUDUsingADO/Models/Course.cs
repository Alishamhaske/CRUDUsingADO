using Microsoft.Build.Framework;

namespace CRUDUsingADO.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int Fee { get; set; }
    }

}

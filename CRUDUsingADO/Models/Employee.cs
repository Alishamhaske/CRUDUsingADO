
using System.ComponentModel.DataAnnotations;


namespace CRUDUsingADO.Models
{
    public class Employee
    {

        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]

        public string? Email { get; set; }
        [Required]

        public int Age { get; set; }
        [Required]
        public double Salary { get; set; }


       
        public string? ImageUrl { get; set; }
        [Required]
        public int Did { get; set; }
        [ScaffoldColumn(false)]
        public string? Dname { get; set; }

        public int IsActive { get; set; }

    }
}

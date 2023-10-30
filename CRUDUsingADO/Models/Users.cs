using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
namespace CRUDUsingADO.Models
{
    public class Users
    {

        public int Id { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
    
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set;}
        

    }
}

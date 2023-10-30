
using System.ComponentModel.DataAnnotations;
namespace CRUDUsingADO.Models
{
    public class Product
    {
        /// <summary>
        /// not  properly  run
        /// </summary>

        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int Price { get; set; }

 
        public string? ImageUrl { get; set; }

        [Required]
        public int Cid { get; set; }
        [ScaffoldColumn(false)]
        public string? Cname { get; set; }

        public int IsActive { get; set; }

    }
}

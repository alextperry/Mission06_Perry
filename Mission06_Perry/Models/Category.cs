using System.ComponentModel.DataAnnotations;

namespace Mission06_Perry.Models
{
    public class Category
    {

        [Key]
        [Required]
        public int CategoryID { get; set; } // categoryID, required 

        [Required]
        public string CategoryName { get; set; } // category name 
    }
}

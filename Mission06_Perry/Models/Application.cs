using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Diagnostics.HealthChecks;


// model that sets up the Application table in the db with different columns 
namespace Mission06_Perry.Models
{
    public class Application
    {
        [Key]
        [Required]
        public int movieID { get; set; } // movieID column, primary key

        [Required]
        public string Category { get; set; } // category column, required

        [Required]
        public string Title { get; set; } // title column, required

        [Required]
        public string Year { get; set; } // year column, required

        [Required]
        public string Director { get; set; } // director column, required

        [Required]
        public string Rating { get; set; } // reating column, required
        

        public string? Edited { get; set; } // edited, not required

        public string? Lent { get; set; } // lent, not required

        [MaxLength(25)]
        public string? Notes { get; set; } // notes, max 25 characters, not required




    }
}

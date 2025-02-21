using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Diagnostics.HealthChecks;


// model that sets up the Application table in the db with different columns 
namespace Mission06_Perry.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int movieID { get; set; } // movieID column, primary key

        [ForeignKey("Category")]
        public int CategoryID { get; set; } // category column, required

        public Category? Category { get; set; }

        [Required] 
        public string Title { get; set; } // title column, required

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "The year must be 1888 or later.")]
        public string Year { get; set; } // year column, required

        public string? Director { get; set; } // director column, required

        public string? Rating { get; set; } // reating column, required

        [Required]
        public int Edited { get; set; } // edited, required

        public string? LentTo { get; set; } // lent, not required


        [Required]
        public int CopiedToPlex { get; set; } // Copied to Plex, required

        [MaxLength(25)]
        public string? Notes { get; set; } // notes, max 25 characters, not required




    }
}

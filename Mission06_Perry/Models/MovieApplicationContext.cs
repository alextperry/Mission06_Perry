using Microsoft.EntityFrameworkCore;


// model that allows the code to connect to the db

namespace Mission06_Perry.Models
{
    public class MovieApplicationContext : DbContext // class that allows interaction with the db
    {   
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options) // constructor
        {

        }

        // setting up the Applications table in the db
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }


    }
}

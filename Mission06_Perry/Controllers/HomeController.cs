using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Perry.Models;
using static System.Net.Mime.MediaTypeNames;


// controller that connects the model with the views 
namespace Mission06_Perry.Controllers
{
    public class HomeController : Controller
    {

        private MovieApplicationContext _context;

        public HomeController(MovieApplicationContext applicant) // constructor 
        {
            _context = applicant;
        }

        public IActionResult Index() // returns index view
        {
            return View();
        }

        public IActionResult Joel() // returns Joel view
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddMovie() // returns collection view
        {

            Movie movie = new Movie();

            ViewBag.Categories = _context.Categories 
                .OrderBy(x => x.CategoryName) 
                .ToList(); 

            ViewBag.Movies = _context.Movies
                .OrderBy(x => x.Title)
                .ToList();


            return View("AddMovie", movie);
        }

        // post method for adding a movie to the db
        [HttpPost]
        public IActionResult AddMovie(Movie response) 
        {

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            if (ModelState.IsValid)
                {
                    _context.Movies.Add(response); // whatever was passed this adds the record to the db 

                    _context.SaveChanges();

                    return View("Addmovie", response); // returns the view and the data to be passed to the db 
                }
            else // invalid data
            {
                return View(response);  
            }

        }



        // returns the collection view 
        public IActionResult Collection()
        {

            var movie = _context.Movies  
                .Include(x => x.Category)
                .OrderBy(x => x.Title).ToList();


            return View(movie);
        }

        // get method for the edit page to get all records and create a viewbag

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies // querying the db with Linq
                .Single(x => x.movieID == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", recordToEdit);
        }

        // post method to return an edited record to the db 

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Collection");
        }


        // getting the method to delete

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.movieID == id);

            return View("Delete", recordToDelete);
        }

        // posting the updated db without the record that was deleted

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Collection");
        }

    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Perry.Models;


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

        public IActionResult Collection() // returns collection view
        {
            return View();
        }


        [HttpPost]
        public IActionResult Collection(Application response)
        {

            _context.Applications.Add(response); // whatever was passed this adds the record to the db

            _context.SaveChanges();

            return View("Collection", response); // returns the view and the data to be passed to the db
        }


    }
}

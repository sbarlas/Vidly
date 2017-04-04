using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
           
            return View(movies);
        }


        [Route("movies/detail/{id}")]
        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            var movieItem = movies.Find(x => x.Id == id);

            if(movieItem == null)
            {
                return HttpNotFound("This movie does not exist");
            }

            return View(movieItem);

        }

        //// GET: Movies
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Id = 1, Name = "Skrek!" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "Customer 1" },
        //        new Customer {Name = "Customer 2" }
        //    };

        //    var viewModel = new RamdomMovieViewModel()
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };  



        //    return View(viewModel);

        //    //return Content("Hello saqib");
        //    //return HttpNotFound("Resource not found");
        //    //return new EmptyResult();

        //    //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

        //    //return RedirectToRoute(new { page = 1, sortBy = "name" });
        //}

        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseYear(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

    }
}
using System;
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
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Skrek!" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1" },
                new Customer {Name = "Customer 2" }
            };

            var viewModel = new RamdomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };  
         


            return View(viewModel);

            //return Content("Hello saqib");
            //return HttpNotFound("Resource not found");
            //return new EmptyResult();

            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

            //return RedirectToRoute(new { page = 1, sortBy = "name" });
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Index()
        {
            var movies = GetStaticMovieList();

            return View(movies);
        }


        [Route("movies/detail/{id}")]
        public ActionResult Details(int id)
        {
            var movieItem = GetStaticMovieList().Find(x => x.Id == id);

            if(movieItem == null)
            {
                return HttpNotFound("This movie does not exist");
            }

            return View(movieItem);

        }

        private List<Movie> GetStaticMovieList()
        {
            var movieList = new List<Movie>()
            {
                new Movie { Id=1, ReleaseDate= new DateTime(1989,2,3), Name="Die Hard" },
                new Movie { Id=2,  ReleaseDate= new DateTime(2001,6,29), Name="Shrek" },
                new Movie { Id=3,  ReleaseDate= new DateTime(1985,12,4), Name="Back to the Future" }
            };

            return movieList;
        }
    }
}
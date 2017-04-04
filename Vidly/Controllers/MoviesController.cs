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

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genre = genres
            };

            return View("MovieForm", viewModel);
        }


        public ActionResult Edit(int id)
        {

            var movieDetails = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieDetails == null)
            {
                return HttpNotFound("Can not find movie");
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movieDetails,
                Genre = _context.Genres.ToList()
            };


            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                // TryUpdateModel(customerInDb);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
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
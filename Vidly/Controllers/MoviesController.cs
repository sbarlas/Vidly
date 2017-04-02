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



            //  ViewData["Movie"] = movie;

            //   ViewBag.Movie = movie;


            return View(viewModel);

            //            return Content("Hello saqib");
            //return HttpNotFound("Resource not found");
            //return new EmptyResult();

           // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";

            }

            return Content(String.Format("Page inde = {0}&sortBy={1}", pageIndex, sortBy));
        }
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year , int month)
        {
            return Content(year + "/" + month);
        }
    }
}
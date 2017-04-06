using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }

        public int? Id { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Please enter the number in stock between 1 and 20")]
        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }

        [Display(Name = "Movie Genre")]
        [Required]
        public int? GenreId { get; set; }


        public string Title
        {
            get
            {
                 return (IsNewMovieForm) ? "New Movie" : "Edit Movie";
            }
        }

        public bool IsNewMovieForm
        {
            get
            {
                return (Id != 0) ? false : true;
            }
        }


        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movieDetails)
        {
            Id = movieDetails.Id;
            Name = movieDetails.Name;
            DateAdded = movieDetails.DateAdded;
            ReleaseDate = movieDetails.ReleaseDate;
            NumberInStock = movieDetails.NumberInStock;
            GenreId = movieDetails.GenreId;
        }

    }
}
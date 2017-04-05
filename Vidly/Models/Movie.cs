using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Movie Genre")]
        [Required]
        public int GenreId { get; set; }
    }
}
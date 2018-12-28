using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vinly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vinly.ViewModels
{
    public class NewMovieViewModel
    {

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Relase Date")]
        [Required(ErrorMessage = "Please enter Relase Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required(ErrorMessage = "Please enter Number in Stock ")]
        public int? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please Select Movie Genre")]
        public int? MovieGenreId { get; set; }

        public IEnumerable <MovieGenre> Genre { get; set; }
        public string PageTitle {
            get{
                if (Id == 0) {
                    return "New Movie";
                }
                return "Edit Movie";
            }
        
        }

        public NewMovieViewModel()
        {
            Id = 0;
        }
        public NewMovieViewModel(Movie movie)
        {

            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            MovieGenreId = movie.MovieGenreId;

        }
    }
}
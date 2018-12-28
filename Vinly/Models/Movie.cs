using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vinly.Models
{
    public class Movie
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name ="Relase Date")]
        [Required(ErrorMessage = "Please enter Relase Date")]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? AddedDate { get; set; }//? is use to indicate nullable

        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        [Required(ErrorMessage = "Please enter Number in Stock ")]
        public int NumberInStock { get; set; }

        public MovieGenre MovieGenre { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please Select Movie Genre")]
        public int MovieGenreId { get; set; }

    }
}
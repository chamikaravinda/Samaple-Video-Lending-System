using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vinly.Dtos
{
    public class MoviesDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? AddedDate { get; set; }//? is use to indicate nullable

        [Range(1, 20)]
        [Required(ErrorMessage = "Please enter Number in Stock ")]
        public int NumberInStock { get; set; }

        [Required]
        public int MovieGenreId { get; set; }
    }
}
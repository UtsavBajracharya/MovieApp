using System;
using System.ComponentModel.DataAnnotations; //Using the directive

namespace MovieList.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set;}
        [Required(ErrorMessage = "Please enter a year.")]
        [Range(1889, 2999, ErrorMessage = "Year must be after 1889.")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Please enter a rating.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]

        public int? Rating { get; set; }

        // Add more fields
        [Required(ErrorMessage = "Please enter a release date.")]
        public DateTime? ReleaseDate { get; set; }  // Added release date

        [Required(ErrorMessage = "Please enter a director.")]
        public string Director { get; set; }  // Added director field

        [Required(ErrorMessage = "Please enter the duration.")]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be a positive number.")]
        public int Duration { get; set; }  // Added duration field (in minutes)

        public Genre Genre { get; set; }
        [Required(ErrorMessage = "Please enter a genre.")]
        public string GenreId { get; set; }

        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + Year?.ToString();
    }
}

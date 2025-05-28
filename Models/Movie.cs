using System;
using System.ComponentModel.DataAnnotations;

public class Movie
{
    public int MovieId { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required(ErrorMessage = "Duration is required.")]
    [Range(31, int.MaxValue, ErrorMessage = "Duration must be greater than 30 minutes.")]
    public int DurationMinutes { get; set; }

    [Required(ErrorMessage = "Release Date is required.")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
}

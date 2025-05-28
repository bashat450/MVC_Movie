using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Booking
{
    public int BookingId { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public virtual Customer Customer { get; set; }

    [Required]
    public int MovieId { get; set; }

    [ForeignKey("MovieId")]
    public virtual Movie Movie { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "At least one seat must be booked.")]
    public int NumberOfSeats { get; set; }

    public DateTime BookingDate { get; set; } = DateTime.Now;
}

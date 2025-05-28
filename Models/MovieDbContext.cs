using System.Data.Entity;

public class MovieDbContext : DbContext
{
    public MovieDbContext() : base("DefaultConnection") { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<User> Users { get; set; }



}

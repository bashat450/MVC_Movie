using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

public class BookingsController : Controller
{
    private MovieDbContext db = new MovieDbContext();

    public ActionResult Index()
    {
        var bookings = db.Bookings.Include("Customer").Include("Movie").ToList();
        return View(bookings);
    }

    public ActionResult Create()
    {
        ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FullName");
        ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Booking booking)
    {
        if (!db.Customers.Any(c => c.CustomerId == booking.CustomerId))
        {
            ModelState.AddModelError("CustomerId", "Customer does not exist.");
        }

        if (!db.Movies.Any(m => m.MovieId == booking.MovieId))
        {
            ModelState.AddModelError("MovieId", "Movie does not exist.");
        }

        if (ModelState.IsValid)
        {
            booking.BookingDate = DateTime.Now;
            db.Bookings.Add(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FullName", booking.CustomerId);
        ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", booking.MovieId);
        return View(booking);
    }
}

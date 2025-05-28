using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

public class UsersController : Controller
{
    private MovieDbContext db = new MovieDbContext();


    public ActionResult Index()
    {
        if (Session["UserId"] == null)
            return RedirectToAction("Login", "Users");

        return View();
    }

    public ActionResult Register()
    {
        return View();
    }
        

    [HttpPost]
    public ActionResult Register(User user)
    {
        if (db.Users.Any(u => u.Username == user.Username))
        {
            ModelState.AddModelError("Username", "Username already exists.");
            return View(user);
        }

        if (ModelState.IsValid)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

        return View(user);
    }

    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(User user)
    {
        var existing = db.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
        if (existing != null)
        {
            Session["UserId"] = existing.UserId;
            Session["Username"] = existing.Username;
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Invalid login!";
        return View();
    }

    public ActionResult Logout()
    {
        Session.Clear();
        return RedirectToAction("Login");
    }
}

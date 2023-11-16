using Microsoft.AspNetCore.Mvc;

namespace NUCA.Identity.Quickstart.Users
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

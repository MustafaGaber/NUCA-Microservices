using Microsoft.AspNetCore.Mvc;

namespace NUCA.Identity.Controllers.Departments
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

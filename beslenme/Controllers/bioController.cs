using Microsoft.AspNetCore.Mvc;

namespace beslenme.Controllers
{
    public class bioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

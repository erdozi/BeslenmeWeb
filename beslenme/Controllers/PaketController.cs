using Microsoft.AspNetCore.Mvc;

namespace beslenme.Controllers
{
    public class PaketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

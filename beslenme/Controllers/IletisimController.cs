using Microsoft.AspNetCore.Mvc;

namespace beslenme.Controllers
{
    public class IletisimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

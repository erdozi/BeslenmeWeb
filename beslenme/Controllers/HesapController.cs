using Microsoft.AspNetCore.Mvc;

namespace beslenme.Controllers
{
    public class HesapController : Controller
    {
        [HttpGet]
        public IActionResult Vki()
        {
            return View();
        }
    }
}

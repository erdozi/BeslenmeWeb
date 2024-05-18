using Microsoft.AspNetCore.Mvc;

namespace beslenme.Controllers
{
    public class TariflerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
    }
}

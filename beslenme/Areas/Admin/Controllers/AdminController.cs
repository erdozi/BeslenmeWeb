using beslenme.Context;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace beslenme.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly uContext _context;

        public AdminController(uContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

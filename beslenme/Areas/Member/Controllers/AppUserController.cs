using beslenme.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace beslenme.Areas.Member.Controllers
{
    [Area("Member")]
    public class AppUserController : Controller
    {
        private readonly uContext _context;

        public AppUserController(uContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userName = HttpContext.Session.GetString("UserName");
            var userProps = await _context.UserProp.Where(a => a.userId == userName).FirstOrDefaultAsync();
            ViewBag.UserName = userName;
            ViewBag.Height = userProps?.boy;
            ViewBag.Weight = userProps?.kilo;
            ViewBag.Gender = userProps?.cinsiyet;

            return View();

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
        }


    }
}

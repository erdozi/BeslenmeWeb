using beslenme.Context;
using beslenme.DTOs;
using beslenme.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace beslenme.Controllers
{
    public class LoginController : Controller
    {
        private readonly uContext _context;

        public LoginController(uContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Kullanici.Where(a => a.sifre == dto.sifre && a.kullaniciAd == dto.kullaniciAdi).FirstOrDefaultAsync();
                if (user != null)
                {




                    

                    HttpContext.Session.SetString("UserName", user.kullaniciAd);



                    return RedirectToAction("Index", "AppUser", new { area = user.rol.ToString() });
                }


            }
            return View(dto);

        }


        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var newUser = new Kullanici
            {
                kullaniciAd = dto.kullaniciAd,
                sifre = dto.sifre,
                rol = "Member" // Varsayılan olarak "Member" rolü atanabilir, isteğe bağlı olarak değiştirilebilir
            };

            _context.Kullanici.Add(newUser);
            await _context.SaveChangesAsync();

            var user = await _context.Kullanici.Where(a => a.sifre == dto.sifre && a.kullaniciAd == dto.kullaniciAd).FirstOrDefaultAsync();


            var userprop = new UserProp
            {
                boy = dto.boy,
                cinsiyet = dto.cinsiyet,
                kilo = dto.kilo,
                yas = dto.yas,
                userId = dto.kullaniciAd,
            };


            _context.UserProp.Add(userprop);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetString("UserName", newUser.kullaniciAd);
            return RedirectToAction("Index", "AppUser", new { area = "Member" });
        }


    }
}

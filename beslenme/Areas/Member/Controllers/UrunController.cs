using beslenme.Context;
using beslenme.Entitites;
using Microsoft.AspNetCore.Mvc;

namespace beslenme.Areas.Member.Controllers
{
    [Area("Member")]
    public class UrunController : Controller
    {
        private readonly uContext _context;

        public UrunController(uContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var urunler = _context.Urun.ToList();
            return View(urunler);
        }

        [HttpPost]
        public IActionResult SepeteEkle(int id, int adet)
        {
            var urun = _context.Urun.Find(id);
            if (urun != null)
            {
                var sepetItem = new Sepet
                {
                    kullaniciAd = HttpContext.Session.GetString("UserName"), // Kullanıcı adını session'dan al
                    ad = urun.ad,
                    aciklama = urun.aciklama,
                    fiyat = urun.fiyat * adet,
                    adet = adet,
                };

                _context.Sepet.Add(sepetItem);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Ürün başarıyla sepete eklendi.";
            }
            return RedirectToAction("Index");
        }
    }
}

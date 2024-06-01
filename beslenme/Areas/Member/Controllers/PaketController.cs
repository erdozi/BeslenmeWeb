using beslenme.Context;
using beslenme.Entitites;
using Microsoft.AspNetCore.Mvc;

namespace beslenme.Areas.Member.Controllers
{
    [Area("Member")]
    public class PaketController : Controller

    {
        private readonly uContext _context;

        public PaketController(uContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            var paketler = _context.Paketlers.ToList();
            return View(paketler);
        }


        [HttpPost]
        public IActionResult SepeteEkle(int id)
        {
            var kullaniciAdi = HttpContext.Session.GetString("UserName");
            var paket = _context.Paketlers.Find(id);
            if (paket != null)
            {
                var mevcutSepetItem = _context.Sepet
                    .FirstOrDefault(s => s.kullaniciAd == kullaniciAdi && s.ad == paket.PaketAd);

                if (mevcutSepetItem != null)
                {
                    TempData["ErrorMessage"] = "Bu paket zaten sepetinizde.";
                }
                else
                {
                    var sepetItem = new Sepet
                    {
                        kullaniciAd = kullaniciAdi, // Kullanıcı adını session'dan al
                        ad = paket.PaketAd,
                        aciklama = paket.PaketAciklama,
                        fiyat = paket.PaketFiyat,
                        adet = 1,
                    };

                    _context.Sepet.Add(sepetItem);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Paket başarıyla sepete eklendi.";
                }
            }
            return RedirectToAction("Index");
        }


    }
}

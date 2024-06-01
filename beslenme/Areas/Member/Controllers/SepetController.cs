using beslenme.Context;
using Microsoft.AspNetCore.Mvc;

namespace beslenme.Areas.Member.Controllers
{
    [Area("Member")]
    public class SepetController : Controller
    {
        private readonly uContext _context;

        public SepetController(uContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                var kullaniciAdi = HttpContext.Session.GetString("UserName");
                var sepetItems = _context.Sepet.Where(s => s.kullaniciAd == kullaniciAdi).ToList();
                return View(sepetItems);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult SepettenSil(int id)
        {
            var sepetItem = _context.Sepet.Find(id);
            if (sepetItem != null)
            {
                _context.Sepet.Remove(sepetItem);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Onayla()
        {
            var kullaniciAdi = HttpContext.Session.GetString("UserName");
            var sepetItems = _context.Sepet.Where(s => s.kullaniciAd == kullaniciAdi).ToList();

            // Sepetteki ürünleri işlemek için gereken işlemler burada yapılır.
            // Örneğin, sipariş oluşturma, ödeme işleme vb.

            // Sepeti temizleme
            _context.Sepet.RemoveRange(sepetItems);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Sepet başarıyla onaylandı.";
            return RedirectToAction("Index", "Paket");
        }

    }
}

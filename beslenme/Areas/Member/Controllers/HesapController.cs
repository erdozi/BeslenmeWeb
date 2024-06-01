using beslenme.Context;
using beslenme.Entitites;
using Microsoft.AspNetCore.Mvc;

namespace beslenme.Areas.Member.Controllers
{
    [Area("Member")]
    public class HesapController : Controller
    {
        private readonly uContext _context;

        public HesapController(uContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult Vki()
        {
            var kullaniciAdi = HttpContext.Session.GetString("UserName");
            var userProp = _context.UserProp.FirstOrDefault(u => u.userId == kullaniciAdi);
            if (userProp != null)
            {
                ViewBag.Boy = userProp.boy;
                ViewBag.Kilo = userProp.kilo;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Vki(decimal boy, decimal kilo)
        {
            double vki = (double)(kilo / (boy * boy));
            string sonuc = $"VKİ: {vki}";

            Kaydet("VKI HESAPLAMA", sonuc);
            ViewBag.Sonuc = sonuc;

            return View();
        }

        [HttpGet]
        public IActionResult IdealKgHesaplama()
        {
            var kullaniciAdi = HttpContext.Session.GetString("UserName");
            var userProp = _context.UserProp.FirstOrDefault(u => u.userId == kullaniciAdi);
            if (userProp != null)
            {
                ViewBag.Boy = userProp.boy;
            }
            return View();
        }

        [HttpPost]
        public IActionResult IdealKgHesaplama(decimal boy)
        {
            double idealKilo = 22 * (double)(boy * boy);
            string sonuc = $"İdeal Kilo: {idealKilo:F2} kg";

            Kaydet("İDEAL KİLO HESAPLAMA", sonuc);
            ViewBag.Sonuc = sonuc;

            return View();
        }

        [HttpGet]
        public IActionResult BelKalcaOraniHesaplama()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BelKalcaOraniHesaplama(decimal bel, decimal kalca)
        {
            double oran = (double)(bel / kalca);
            string sonuc = $"Bel/Kalça Oranı: {oran:F2}";

            Kaydet("BEL KALÇA ORANI HESAPLAMA", sonuc);
            ViewBag.Sonuc = sonuc;

            return View();
        }

        [HttpGet]
        public IActionResult BazalMetabolizm()
        {
            var kullaniciAdi = HttpContext.Session.GetString("UserName");
            var userProp = _context.UserProp.FirstOrDefault(u => u.userId == kullaniciAdi);
            if (userProp != null)
            {
                ViewBag.Kilo = userProp.kilo;
                ViewBag.Boy = userProp.boy;
                ViewBag.Yas = userProp.yas;
                ViewBag.Cinsiyet = userProp.cinsiyet;
            }
            return View();
        }

        [HttpPost]
        public IActionResult BazalMetabolizm(decimal kilo, decimal boy, int yas, string cinsiyet)
        {
            double bmh;
            if (cinsiyet == "Erkek")
            {
                bmh = 88.36 + (13.4 * (double)kilo) + (4.8 * (double)boy) - (5.7 * yas);
            }
            else
            {
                bmh = 447.6 + (9.2 * (double)kilo) + (3.1 * (double)boy) - (4.3 * yas);
            }
            string sonuc = $"Bazal Metabolizma Hızı: {bmh:F2} kcal";

            Kaydet("BAZAL METABOLİZMA HIZI HESAPLAMA", sonuc);
            ViewBag.Sonuc = sonuc;

            return View();
        }

        [HttpGet]
        public IActionResult Consultation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Consultation(string hesaplamaTuru, decimal deger1, decimal deger2, decimal deger3 = 0)
        {
            string sonuc = "";

            switch (hesaplamaTuru)
            {
                case "DÜZELTİLMİŞ AĞIRLIK HESAPLAMA":
                    sonuc = $"Düzeltilmiş Ağırlık: {deger1:F2} kg"; // Hesaplama işlemi burada yapılmalı
                    break;
                case "ENERJİ HESAPLAMA":
                    sonuc = $"Enerji: {deger2:F2} kcal"; // Hesaplama işlemi burada yapılmalı
                    break;
                case "AKTİVİTE FAKTÖRÜ İLE KALORİ HESAPLAMA":
                    sonuc = $"Kalori: {deger3:F2} kcal"; // Hesaplama işlemi burada yapılmalı
                    break;
                default:
                    sonuc = "Geçersiz hesaplama türü.";
                    break;
            }

            Kaydet(hesaplamaTuru, sonuc);
            ViewBag.Sonuc = sonuc;

            return View();
        }

        private void Kaydet(string hesapTuru, string sonuc)
        {
            var kullaniciAdi = HttpContext.Session.GetString("UserName");

            var hesap = new Hesap
            {
                KullaniciAdi = kullaniciAdi,
                HesapTuru = hesapTuru,
                Sonuc = sonuc
            };

            _context.Hesap.Add(hesap);
            _context.SaveChanges();
        }
    }
}


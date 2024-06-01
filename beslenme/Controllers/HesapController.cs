using beslenme.DTOs;
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

        [HttpPost]
        public IActionResult Vki(VkiDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto); // Hatalı model durumunda aynı view'i tekrar göster
            }

            // VKİ hesaplama formülü: kilo / (boy * boy)
            var sonuc = (dto.kg / (dto.boy * dto.boy)) * 10000;

            ViewBag.Sonuc = sonuc; // Sonucu view'e taşı

            return View(dto); // VKİ hesaplandıktan sonra view'i tekrar göster


        }


        [HttpGet]
        public IActionResult idealKgHesaplama()
        {

            return View();
        }

        [HttpPost]
        public IActionResult idealKgHesaplama(İdealDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto); // Hatalı model durumunda aynı view'i tekrar göster
            }

            // VKİ hesaplama formülü: kilo / (boy * boy)
            var sonuc = dto.boy;

            ViewBag.Sonuc = sonuc; // Sonucu view'e taşı

            return View(dto); // VKİ hesaplandıktan sonra view'i tekrar göster


        }

        [HttpGet]
        public IActionResult belKalcaOraniHesaplama()
        {

            return View();
        }

        [HttpPost]
        public IActionResult belKalcaOraniHesaplama(belKalcaDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto); // Hatalı model durumunda aynı view'i tekrar göster
            }

            var sonuc = dto.bel / dto.kalca;

            ViewBag.Sonuc = sonuc; // Sonucu view'e taşı

            return View(dto); // Oranı hesaplandıktan sonra view'i tekrar göster
        }


        [HttpGet]
        public IActionResult bazalMetabolizmHiziHesaplama()
        {

            return View();
        }

        [HttpPost]
        public IActionResult bazalMetabolizmaHiziHesaplama(bazalMetabolizmaHiziDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto); // Hatalı model durumunda aynı view'i tekrar göster
            }

            // VKİ hesaplama formülü: kilo / (boy * boy)
            var sonuc = dto.boy;

            ViewBag.Sonuc = sonuc; // Sonucu view'e taşı

            return View(dto); // VKİ hesaplandıktan sonra view'i tekrar göster
        }
        
    }
}




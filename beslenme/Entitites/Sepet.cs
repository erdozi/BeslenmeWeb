using Microsoft.AspNetCore.Mvc.RazorPages;

namespace beslenme.Entitites
{
    public class Sepet
    {
        public int id { get; set; }

        public string? ad { get; set; }
        public string? kullaniciAd { get; set; }
        public string? aciklama { get; set; }
        public decimal ?fiyat { get; set; }
        public string ?indirimKod { get; set; }
        public decimal? indirimTutar { get; set; }
        public decimal? toplamTutar { get; set; }
        public int? adet { get; set; }

    }
}

namespace beslenme.DTOs
{
    public class RegisterDTO
    {
        public string kullaniciAd { get; set; }
        public string sifre { get; set; }
        public string rol { get; set; }


        //
        public string? userId { get; set; }

        public decimal? boy { get; set; }

        public decimal? kilo { get; set; }

        public int? yas { get; set; }

        public string? cinsiyet { get; set; }
    }
}

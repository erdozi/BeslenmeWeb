using beslenme.Entitites;
using Microsoft.EntityFrameworkCore;

namespace beslenme.Context
{
    public class uContext:DbContext
    {
        public uContext(DbContextOptions<uContext> opt) : base(opt)
        {
           

        }

        public DbSet<Hesap> Hesap { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<UserProp> UserProp { get; set; }
        public DbSet<Paketler> Paketlers { get; set; }
        public DbSet<Sepet> Sepet { get; set; }
        public DbSet<Urun> Urun { get; set; }


        





    }
}

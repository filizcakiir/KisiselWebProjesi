using Microsoft.EntityFrameworkCore;


namespace KisiselWebProjesi.Models.Siniflar
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AnaSayfa> AnaSayfas  { get; set; }
        public DbSet<ikonlar> ikonlars { get; set; }
    }
}

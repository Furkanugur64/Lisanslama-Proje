using WebApi.Models;
using Microsoft.EntityFrameworkCore;
using LisansProje.Models;

namespace WebApi.Models
{
    public class Context: DbContext
    {
        public DbSet<Lisans> Licences { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Kurum> Kurums { get; set; }
        //public DbSet<Namaz> NamazVakitleri { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // model oluşturma işlemleri
        }
    }
}

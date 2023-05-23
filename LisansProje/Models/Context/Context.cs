using Microsoft.EntityFrameworkCore;

namespace LisansProje.Models.Context
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=FRKN\\SQLEXPRESS;database=DB_Lisans; integrated security=true;TrustServerCertificate=True");
		}

		public DbSet<Admin> Admins { get; set; }
		public DbSet<Lisans> Licences { get; set; }
		public DbSet<Kurum> Kurums { get; set; }
		public DbSet<Firma> Companys { get; set; }
		public DbSet<Urun> Products { get; set; }
		

	}
}

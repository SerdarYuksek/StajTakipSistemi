using EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class DataContext : DbContext
	{
        //Veri tabanı bağlantısı yapıldı ve tablo adları belirlendi

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=SEDO; database=Stajtakip; integrated security=true; TrustServerCertificate=True;");
		}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dosya>()
                .HasOne(d => d.stajBilgi)
                .WithMany(s => s.dosyas)
                .HasForeignKey(d => d.StajId);
        }
        public DbSet<Student> students { get; set; }
		public DbSet<Personal> personals { get; set; }
		public DbSet<StajBilgi> stajBilgis { get; set; }
		public DbSet<Dosya> dosyas { get; set; }
        public DbSet<Anket> ankets { get; set; }
    }
}

using Microsoft.EntityFrameworkCore; //DbContext, DbSet, DbContextOptions gibi ef komutları bu namespace içinde
using StajyerTakip.Models.DbModels;

namespace StajyerTakip.DAL
{
    public class AppDbContext : DbContext //AppDbContext, DbContext sınıfından kalıtım alıyor
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)  //aldığımız options nesnesini üst sınıfa gönderiyoruz.
        { 
            //Constructor
        }

        
        
        //Dbset
        public DbSet<Beceri> Beceriler { get; set; }

        public DbSet<BeceriKategori> BeceriKategorileri { get; set; }

        public DbSet<Degerlendirme> Degerlendirmeler { get; set; }

        public DbSet<DegerlendirmeKriteri> DegerlendirmeKriterleri { get; set; }

        public DbSet<Departman> Departmanlar { get; set; }

        public DbSet<Dosya> Dosyalar { get; set; }

        public DbSet<DosyaKategori> DosyaKategorileri { get; set; }

        public DbSet<Kullanici> Kullanicilar { get; set; }

        public DbSet<Link> Linkler { get; set; }

        public DbSet<Modul> Moduller { get; set; }

        public DbSet<Proje> Projeler { get; set; }

        public DbSet<Referans> Referanslar { get; set; }

        public DbSet<Rol> Roller { get; set; }

        public DbSet<RolModulYetki> RolModulYetkileri { get; set; }

        public DbSet<Stajyer> Stajyerler { get; set; }  //Stajyer adında bir entity'm var ve bunu veritabanında Stajyerler tablosu olarak yöneteceğim.

        public DbSet<StajyerBeceri> StajyerBecerileri { get; set; }

        public DbSet<Yorum> Yorumlar { get; set; }

        public DbSet<AuditLog> AuditLogs { get; set; }



        //OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Beceri>()
                .HasKey(x => x.BeceriId);

            modelBuilder.Entity<Beceri>()
                .HasOne(d => d.BeceriKategori)
                .WithMany(k => k.Beceriler)
                .HasForeignKey(x => x.BeceriKategoriId)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<BeceriKategori>()
                .HasKey(x => x.BeceriKategoriId);

            
            
            modelBuilder.Entity<Degerlendirme>()
                .HasKey(x => x.DegerlendirmeId);

            modelBuilder.Entity<Degerlendirme>()
                .HasOne(d => d.Degerlendiren) //Her değerlendirmenin bir değerlendiren kullanıcısı vardır.
                .WithMany(k => k.Degerlendirmeler) //Bir kullanıcı bir çok değerlendirmeler yapabilir.
                .HasForeignKey(d => d.DegerlendirenId) //FK
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Degerlendirme>()
                .HasOne(d => d.Kriter) //Her değerlendirmenin bir kriter değerlendirme kriteri vardır.
                .WithMany(k => k.Degerlendirmeler)//Bir değerlendirme kriterinin bir çok değerlendirmeleri olabilir.
                .HasForeignKey(d => d.KriterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Degerlendirme>()
                .HasOne(d => d.Stajyer) //Her değerlendirmenin bir stajyeri vardır
                .WithMany(s => s.Degerlendirmeler) //Bir stajyerin bir çok değerlendirmesi olabilir
                .HasForeignKey(d =>d.StajyerId)
                .OnDelete(DeleteBehavior.Restrict);


            
            
            modelBuilder.Entity<DegerlendirmeKriteri>()
                .HasKey(x => x.KriterId);

           

            
            modelBuilder.Entity<Departman>()
                .HasKey(x => x.DepartmanId);


            
            
            modelBuilder.Entity<Dosya>()
                .HasKey(x =>x.DosyaId);

            modelBuilder.Entity<Dosya>()
                .HasOne(d => d.DosyaKategori)
                .WithMany(k => k.Dosyalar)
                .HasForeignKey(d => d.DosyaKategoriId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Dosya>()
                .HasOne(d => d.Stajyer)
                .WithMany(k => k.Dosyalar)
                .HasForeignKey(d => d.StajyerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Dosya>()
                .HasOne(d => d.Yukleyen)
                .WithMany(k => k.Dosyalar)
                .HasForeignKey(d => d.YukleyenId)
                .OnDelete(DeleteBehavior.Restrict);



            
            modelBuilder.Entity<DosyaKategori>()
                .HasKey(x=>x.DosyaKategoriId);



            
            modelBuilder.Entity<Kullanici>()
                .HasKey(x => x.KullaniciId);

            modelBuilder.Entity<Kullanici>()
                .HasOne(d => d.Rol)
                .WithMany(k => k.Kullanicilar)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Kullanici>()
                .HasOne(d=>d.Departman)
                .WithMany(k=>k.Kullanicilar)
                .HasForeignKey(d=>d.DepartmanId) 
                .OnDelete(DeleteBehavior.Restrict);


            
            modelBuilder.Entity<Link>()
                .HasKey(x => x.LinkId);

            modelBuilder.Entity<Link>()
                .HasOne(d=>d.Stajyer)
                .WithMany(k=>k.Linkler)
                .HasForeignKey(d=>d.StajyerId) 
                .OnDelete(DeleteBehavior.Restrict);


            
            modelBuilder.Entity<Modul>()
                .HasKey(x => x.ModulId);


            
            modelBuilder.Entity<Proje>()
                .HasKey(x=>x.ProjeId);

            modelBuilder.Entity<Proje>()
                .HasOne(d => d.Stajyer)
                .WithMany(k => k.Projeler)
                .HasForeignKey(d => d.StajyerId)
                .OnDelete(DeleteBehavior.Restrict);


            
            modelBuilder.Entity<Referans>()
                .HasKey(x => x.ReferansId);

            modelBuilder.Entity<Referans>()
                .HasOne(d => d.Stajyer)
                .WithMany(k => k.Referanslar)
                .HasForeignKey(d => d.StajyerId)
                .OnDelete(DeleteBehavior.Restrict);

            
            
            modelBuilder.Entity<Rol>()
                .HasKey(x => x.RolId);


            
            modelBuilder.Entity<RolModulYetki>()
                .HasKey(x => new { x.RolId, x.ModulId });

            modelBuilder.Entity<RolModulYetki>()
                .HasOne(d=>d.Rol)
                .WithMany(k=>k.RolModulYetkileri)
                .HasForeignKey(d=>d.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RolModulYetki>()
                .HasOne(d=>d.Modul)
                .WithMany(k=>k.RolModulYetkileri)
                .HasForeignKey(d=>d.ModulId)
                .OnDelete(DeleteBehavior.Restrict);


            
            modelBuilder.Entity<Stajyer>()
                .HasKey(x=>x.StajyerId);

            modelBuilder.Entity<Stajyer>()
                .HasOne(d => d.Departman)
                .WithMany(k => k.Stajyerler)
                .HasForeignKey(d => d.DepartmanId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Stajyer>()
                .HasOne(d => d.Mentor)
                .WithMany(k => k.Stajyerler)
                .HasForeignKey(d => d.MentorId)
                .OnDelete(DeleteBehavior.Restrict);



            
            modelBuilder.Entity<StajyerBeceri>()
                .HasKey(x => new { x.StajyerId, x.BeceriId });


            modelBuilder.Entity<StajyerBeceri>()
                .HasOne(d=>d.Stajyer)
                .WithMany(k=>k.StajyerBecerileri)
                .HasForeignKey(d=>d.StajyerId) 
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StajyerBeceri>()
                .HasOne(d => d.Beceri)
                .WithMany(k => k.StajyerBecerileri)
                .HasForeignKey(d => d.BeceriId)
                .OnDelete(DeleteBehavior.Restrict);

           
            
           
            modelBuilder.Entity<Yorum>()
                .HasKey(x => x.YorumId);

            modelBuilder.Entity<Yorum>()
                .HasOne(d => d.Stajyer)
                .WithMany(k => k.Yorumlar)
                .HasForeignKey(d => d.StajyerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Yorum>()
                .HasOne(d=>d.Yazan)
                .WithMany(k=>k.Yorumlar)
                .HasForeignKey(d=>d.YazanId) 
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AuditLog>()
                .HasKey(x => x.AuditLogId);



        }






    }
}

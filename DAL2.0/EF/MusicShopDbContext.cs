using DAL2._0.Configurations;
using DAL2._0.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL2._0.EF
{
    internal class MusicShopDbContext : DbContext
    {

        public MusicShopDbContext()
            : base("name=MusicShopDbContext")
        {
            Database.SetInitializer(new Initializer());

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>().Property(p => p.Login)
                .IsRequired()
                .HasMaxLength(100);
               
            modelBuilder.Entity<Account>().Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<AccountType>().Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Artist>().Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Genre>().Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Plate>().Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Publisher>().Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Track>().Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Genre>().HasOptional(g => g.Discount)
                .WithRequired(d => d.Genre);
            modelBuilder.Entity<Discount>().Property(d => d.DiscountAmount).IsRequired();
            modelBuilder.Entity<Discount>().HasKey(d => d.Id);
            modelBuilder.Entity<Reservation>().HasKey(r => r.Id);
            

            modelBuilder.Entity<Account>().HasOptional(a=>a.Plates);
            modelBuilder.Configurations.Add(new BandConfig());
            modelBuilder.Configurations.Add(new PlateConfig());
            modelBuilder.Configurations.Add(new AccountConfig());
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Band> Bands { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Plate> Plates { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        

    }

}

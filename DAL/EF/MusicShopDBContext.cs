using DAL.Configurations;
using DAL.EF;
using DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
namespace DAL
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

            modelBuilder.Configurations.Add(new BandConfig());
            modelBuilder.Configurations.Add(new PlateConfig());
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Band> Bands { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Plate> Plates { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

    }
}
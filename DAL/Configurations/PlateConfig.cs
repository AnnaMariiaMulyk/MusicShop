using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configurations
{
    public class PlateConfig:EntityTypeConfiguration<Plate>
    {
        public PlateConfig()
        {
            this.ToTable("Plates")
                .HasKey(p => p.Id);
            this.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
            this.HasRequired(p => p.Publisher)
                .WithMany(p => p.Plates)
                .HasForeignKey(p => p.PublisherId);
            this.HasRequired(p => p.Band)
                .WithMany(b => b.Plates)
                .HasForeignKey(p => p.BandId);
            this.HasRequired(p => p.Genre)
                .WithMany(g => g.Plates)
                .HasForeignKey(p => p.GenreId);
            this.HasMany(p => p.Tracks)
                .WithRequired(t => t.Plate);

        }
    }
}

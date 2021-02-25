using DAL2._0.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL2._0.Configurations
{
    public class PlateConfig : EntityTypeConfiguration<Plate>
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
                .HasForeignKey(p => p.PublisherId)
                .WillCascadeOnDelete(false);

            this.HasRequired(p => p.Band)
                .WithMany(b => b.Plates)
                .HasForeignKey(p => p.BandId)
                .WillCascadeOnDelete(false);

            this.HasRequired(p => p.Genre)
                .WithMany(g => g.Plates)
                .HasForeignKey(p => p.GenreId)
                .WillCascadeOnDelete(false);

            this.HasMany(p => p.Tracks)
                .WithRequired(t => t.Plate)
                .WillCascadeOnDelete(false);

            this.HasOptional(p => p.Reservation)
                .WithRequired(r => r.Plate);
        }
    }
}

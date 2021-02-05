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
    public class BandConfig:EntityTypeConfiguration<Band>
    {
        public BandConfig()
        {
            this.ToTable("Bands")
                .HasKey(b => b.Id);
            this.Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();
            this.HasMany(b => b.Members)
                .WithRequired(m => m.Band);
                
        }
    }
}

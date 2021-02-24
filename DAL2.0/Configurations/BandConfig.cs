using DAL2._0.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL2._0.Configurations
{
    public class BandConfig : EntityTypeConfiguration<Band>
    {
        public BandConfig()
        {
            this.ToTable("Bands")
                .HasKey(b => b.Id);
            this.Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();
                

            this.HasMany(b => b.Members)
                .WithRequired(m => m.Band)
                .WillCascadeOnDelete(false);

        }
    }
}

using DAL2._0.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL2._0.Configurations
{
    public class AccountConfig : EntityTypeConfiguration<Account>
    {
        public AccountConfig()
        {
            this.ToTable("Accounts")
                .HasKey(a => a.Id);
            this.Property(a => a.Login)
                .HasMaxLength(100)
                .IsRequired();
            this.Property(a => a.Password)
                .HasMaxLength(100)
                .IsRequired();
            this.HasRequired(a => a.AccountType)
                .WithMany(a => a.Accounts);
            this.Property(a => a.MoneyBalance)
                .IsOptional(); 
            this.Property(a => a.AmountOfPurchases)
                 .IsOptional();
            this.HasOptional(a => a.Reservation)
              .WithRequired(r => r.Account);
                
               
        }
    }
}

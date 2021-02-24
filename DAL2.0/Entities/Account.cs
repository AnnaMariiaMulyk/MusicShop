using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL2._0.Entities
{
    public class Account
    {
        public Account()
        {
            Plates = new HashSet<Plate>();
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public decimal ?MoneyBalance { get; set; }
        public decimal ?AmountOfPurchases { get; set; }
        public int AccountTypeId { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<Plate> Plates { get; set; }

        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}

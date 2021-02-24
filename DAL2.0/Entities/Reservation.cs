using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL2._0.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int PlateId { get; set; }
        public virtual Plate Plate { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

    }
}

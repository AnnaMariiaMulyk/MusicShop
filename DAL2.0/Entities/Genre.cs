using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL2._0.Entities
{
    public class Genre
    {
        public Genre()
        {
            Plates = new HashSet<Plate>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Plate> Plates { get; set; }
        public int? DiscountId { get; set; }
        public virtual Discount Discount { get; set; }
    }
}

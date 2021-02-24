using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL2._0.Entities
{
    public class Discount
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public  virtual Genre Genre { get; set; }
        public int DiscountAmount { get; set; }
    }
}

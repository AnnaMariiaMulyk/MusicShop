using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Publisher
    {
        public Publisher()
        {
            Plates = new HashSet<Plate>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Plate> Plates { get; set; }

    }
}

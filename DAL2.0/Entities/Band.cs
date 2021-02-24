using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL2._0.Entities
{
    public class Band
    {
        public Band()
        {
            Members = new HashSet<Artist>();
            Plates = new HashSet<Plate>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Artist> Members { get; set; }
        public virtual ICollection<Plate> Plates { get; set; }

    }
}

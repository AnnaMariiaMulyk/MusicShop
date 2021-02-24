using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL2._0.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BandId { get; set; }
        public virtual Band Band { get; set; }
    }
}

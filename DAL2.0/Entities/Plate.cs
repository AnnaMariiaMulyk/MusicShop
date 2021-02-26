using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL2._0.Entities
{
    public class Plate
    {
        public Plate()
        {
            Tracks = new HashSet<Track>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int PublishingYear { get; set; }
        public decimal CoastPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int? ReservationId { get; set; }

        public int BandId { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
        public int? AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual Band Band { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual Genre Genre { get; set; }
    }
    
}

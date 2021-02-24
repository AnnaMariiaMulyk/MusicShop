using DAL2._0.EF;
using DAL2._0.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL2._0
{
    public class DALService
    {
        private MusicShopDbContext _context;
        public DALService()
        {
            _context = new MusicShopDbContext();
        }
        public IQueryable<Band> GetAllBands()
        {
            return _context.Bands;
        }
        public IQueryable<Plate>GetAllPlates()
        {
            return _context.Plates;
        }
        public IQueryable<Artist>GetAllArtists()
        {
            return _context.Artists;
        }
        public void AddPlate(Plate plate)
        {
            _context.Plates.Add(plate);
        }
        public void AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
        public void AddArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            _context.SaveChanges();
        }
        public void AddBand(Band band)
        {
            _context.Bands.Add(band);
            _context.SaveChanges();
        }
        public void AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
        public void AddPublisher(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }
        public void AddTrack(Track track)
        {
            _context.Tracks.Add(track);
            _context.SaveChanges();
        }
        public void DowngradePrice(int genreId)
        {
            foreach (var g in _context.Genres)
            {
                if(g.Id == genreId)
                {
                    foreach (var p in g.Plates)
                        p.SalePrice -= p.SalePrice - (p.SalePrice / 10);
                }
            }
            _context.SaveChanges();
        }
        public void DeletePlate(int plateId)
        {
            var plate = _context.Plates.Find(plateId);
            _context.Plates.Remove(plate);
            _context.SaveChanges();
        }
        public void ChangePlateSalePrice(decimal newPrice, int plateId)
        {
            var plate = _context.Plates.Find(plateId);
            plate.SalePrice = newPrice;
            _context.SaveChanges();
        }
        public void ChangeCoastPrice(decimal newPrice, int plateId)
        {
            var plate = _context.Plates.Find(plateId);
            plate.SalePrice = newPrice;
            _context.SaveChanges();
        }
    }
}

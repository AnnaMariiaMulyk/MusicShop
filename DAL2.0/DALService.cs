using DAL2._0.EF;
using DAL2._0.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public Account GetAccount(string login, string password)
        {
            var account = new Account();
            foreach(var a in _context.Accounts)
            {
                if (a.Login==login && ComputeSha256Hash(password) == a.Password)
                {
                    account = _context.Accounts.Find(a.Id);
                }
            }
            return account;
        }
        public void AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
        public void AddAccountType(AccountType accountType)
        {
            _context.AccountTypes.Add(accountType);
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
        public void AddDiscount(int genreId, int discountAmount)
        {
            foreach (var g in _context.Genres)
            {
                if (g.Id == genreId)
                {
                    foreach (var p in g.Plates)
                        p.SalePrice = p.SalePrice - ((p.SalePrice / 100)*discountAmount);
                        Discount discount = new Discount() { GenreId = genreId, DiscountAmount = discountAmount };
                        _context.Discounts.Add(discount);
                        _context.SaveChanges();
                }
            }
        }
        public void RemoveDiscount(int discountId)
        {
            var discount = _context.Discounts.Find(discountId);
            if(discount!=null)
            { 
                foreach (var p in _context.Plates)
                {
                    if(p.GenreId == discount.GenreId)
                    {
                        p.SalePrice = p.CoastPrice + 100;
                    }
                }
                _context.Discounts.Remove(discount);
                _context.SaveChanges();
            }
        }
        public void AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
        public void AddPlate(Plate plate)
        {
            _context.Plates.Add(plate);
        }
        public void RemovePlate(int plateId)
        {
            var plate = _context.Plates.Find(plateId);
            if (plate == null) { return; }
            
                _context.Plates.Remove(plate);
                _context.SaveChanges();
            
        }
        public void AddPublisher(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public void AddReservation(int plateId, int accountId)
        {
            var acc = _context.Accounts.Find(accountId);
            if(acc!=null)
            {
                var pl = _context.Plates.Find(plateId);
                if(pl!=null)
                {
                    Reservation reservation = new Reservation() { AccountId = accountId, PlateId = plateId };
                    _context.Reservations.Add(reservation);
                    //acc.Reservation
                    _context.SaveChanges();
                }
            }
        }
        public void RemoveReservation(int reservationId)
        {
            var reservation = _context.Reservations.Find(reservationId);
            if(reservation!=null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
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
            if (plate == null) { return; }
            
                _context.Plates.Remove(plate);
                _context.SaveChanges();
            
        }
        public void ChangePlateSalePrice(decimal newPrice, int plateId)
        {
            var plate = _context.Plates.Find(plateId);
            if (plate == null) { return; }

            plate.SalePrice = newPrice;
            _context.SaveChanges();
        }
        public void ChangeCoastPrice(decimal newPrice, int plateId)
        {
            var plate = _context.Plates.Find(plateId);
            if (plate == null) { return; }
            plate.SalePrice = newPrice;
            _context.SaveChanges();
        }
        public void ChangePlateName(string name, int plateId)
        {
            var plate = _context.Plates.Find(plateId);
            if (plate == null) { return; }
            plate.Name = name;
            _context.SaveChanges();
        }
        public void SellPlate(int plateId, int accountId)
        {
            var plate = _context.Plates.Find(plateId);
            if (plate == null) { return; }
            var account = _context.Accounts.Find(accountId);
            if (account == null) { return; }
            if(account.MoneyBalance>=plate.SalePrice)
            {
                account.MoneyBalance -= plate.SalePrice;
                account.AmountOfPurchases += plate.SalePrice;
                account.Plates.Add(plate);
                _context.Plates.Remove(plate);
                Console.WriteLine("Plate succesfuly bought!");
            }
            else
                Console.WriteLine("You don`t have enought money to buy the plate");
           // _context.SaveChanges();
        }
        public void AddMoneyToAccount(int accountId, decimal moneyAdd)
        {
            var account = _context.Accounts.Find(accountId);
            if (account == null) { return; }
            account.MoneyBalance += moneyAdd;
            _context.SaveChanges();
        }
        public void ChangePassword(int accountId, string newPasswd)
        {
            var account = _context.Accounts.Find(accountId);
            if (account == null) { return; }
            account.Password = ComputeSha256Hash(newPasswd);
            _context.SaveChanges();
        }
        public void ChangeLogin(int accountId, string newLogin)
        {
            var account = _context.Accounts.Find(accountId);
            if (account == null) { return; }
            foreach (var a in _context.Accounts)
            {
                if (a.Login == newLogin)
                {
                    Console.WriteLine("Account with this login is already exist");
                    Console.ReadKey();
                    return;
                }
            }
            account.Login = newLogin;
            Console.WriteLine("Account login succesfuly changed");
            _context.SaveChanges();
        }

        public IQueryable<Plate> FindPlateByName(string name)
        {
            return _context.Plates.Where(p => p.Name == name);
        }
        public IQueryable<Plate> FindPlateByGenre(string genre)
        {
            return _context.Plates.Where(p => p.Genre.Name == genre);
        }
        public IQueryable<Plate> FindPlateByBand(string band)
        {
            return _context.Plates.Where(p => p.Band.Name == band);
        }
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

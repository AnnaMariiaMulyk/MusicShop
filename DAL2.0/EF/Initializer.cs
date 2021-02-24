using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL2._0.Entities;
using System.Security.Cryptography;

namespace DAL2._0.EF
{
    //CreateDatabaseIfNotExists<MusicShopDbContext>
    internal class Initializer : CreateDatabaseIfNotExists<MusicShopDbContext>
    {
        //protected override void Seed(MetroDbContext context)
        //{
        //    base.Seed(context);

        //    // POSITIONS
        //    var waiterPos = context.Positions.Add(new Position() { Name = "Waiter" });
        //    var adminPos = context.Positions.Add(new Position() { Name = "Administrator" });
        //    var barmanPos = context.Positions.Add(new Position() { Name = "Barman" });
        //    var managerPos = context.Positions.Add(new Position() { Name = "Manager" });
        //    context.SaveChanges();

        //    // PAYMENT METHODS
        //    var cardMethod = context.PaymentMethods.Add(new PaymentMethod() { Name = "With Credit Card" });
        //    var payPassMethod = context.PaymentMethods.Add(new PaymentMethod() { Name = "By PayPass" });
        //    var cashMethod = context.PaymentMethods.Add(new PaymentMethod() { Name = "By Cash" });
        //    context.SaveChanges();

        //    // MEALS
        //    context.Meals.Add(new Meal()
        //    {
        //        Name = "Borsch",
        //        Description = "Tradition Ukrainian Meal",
        //        Price = 15,
        //        Weight = 150
        //    });
        //    context.Meals.Add(new Meal()
        //    {
        //        Name = "Blin",
        //        Description = null,
        //        Price = 30,
        //        Weight = 240
        //    });
        //    context.Meals.Add(new Meal()
        //    {
        //        Name = "Fridgen Forel",
        //        Description = "Lorem Ipsum aherha; gje;ao gaerg aergaeurhg eah rare.",
        //        Price = 450,
        //        Weight = 320
        //    });
        //    context.SaveChanges();

        //    // EMPLOYEES
        //    var emp1 = context.Employees.Add(new Employee()
        //    {
        //        Name = "Vova",
        //        Surname = "Galoka",
        //        PositionId = waiterPos.Id,
        //        Salary = 7800
        //    });
        //    var emp2 = context.Employees.Add(new Employee()
        //    {
        //        Name = "Viktoria",
        //        Surname = "Surik",
        //        PositionId = waiterPos.Id,
        //        Salary = 9300
        //    });
        //    var emp3 = context.Employees.Add(new Employee()
        //    {
        //        Name = "Luda",
        //        Surname = "Milunka",
        //        PositionId = adminPos.Id,
        //        Salary = 13000,
        //    });
        //    var emp4 = context.Employees.Add(new Employee()
        //    {
        //        Name = "Viktor",
        //        Surname = "Piston",
        //        PositionId = adminPos.Id,
        //        Salary = 4500
        //    });
        //    var emp5 = context.Employees.Add(new Employee()
        //    {
        //        Name = "Taras",
        //        Surname = "Corsa",
        //        PositionId = waiterPos.Id,
        //        Salary = 6900
        //    });
        //    context.SaveChanges();

        //    // PASSPORTS
        //    Passport p1 = context.Passports.Add(new Passport()
        //    {
        //        Number = "000068473",
        //        Authority = "4567",
        //        EmployeeId = emp1.Id
        //    });
        //    emp1.PassportId = p1.EmployeeId;
        //    Passport p2 = context.Passports.Add(new Passport()
        //    {
        //        Number = "000031344",
        //        Authority = "2375",
        //        EmployeeId = emp2.Id
        //    });
        //    emp2.PassportId = p2.EmployeeId;

        //    context.SaveChanges();
        //}
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
        
        protected override void Seed(MusicShopDbContext context)
        {
            base.Seed(context);

            //BANDS
            var band1 = new Band();
            var band2 = new Band();
            context.SaveChanges();

            //ARTISTS
            var artist1 = context.Artists.Add(new Artist() { Name = "Michael Joseph Jackson", BandId = band1.Id });
            var artist2 = context.Artists.Add(new Artist() { Name = "Adam Noah Levine", BandId = band2.Id });
            band1 = context.Bands.Add(new Band() { Name = "The Beatles", Members = new List<Artist> { artist1 } });
            band2 = context.Bands.Add(new Band() { Name = "Maroon 5", Members = new List<Artist> { artist2 } });
            context.SaveChanges();

            //PUBLISHERS
            var pb1 = new Publisher();
            var pb2 = new Publisher();
            context.SaveChanges();

            //PLATES
            var pl1 = new Plate();
            var pl2 = new Plate();
            context.SaveChanges();

            //GENRES
            var gn1 = new Genre();
            var gn2 = new Genre();
            context.SaveChanges();

            //TRACKS
            var tr1 = context.Tracks.Add(new Track() { Name = "Animals", PlateId = pl1.Id });
            var tr2 = context.Tracks.Add(new Track() { Name = "Maps", PlateId = pl1.Id });
            var tr3 = context.Tracks.Add(new Track() { Name = "Come Together", PlateId = pl2.Id });
            var tr4 = context.Tracks.Add(new Track() { Name = "Something", PlateId = pl2.Id });
            pl1 = context.Plates.Add(new Plate() { Name = "V", PublishingYear = 2014, CoastPrice = 150, SalePrice = pl1.CoastPrice + 100, 
                BandId = band2.Id, PublisherId = pb1.Id, Tracks = new List<Track> { tr1, tr2 }, GenreId = gn1.Id });
            pl2 = context.Plates.Add(new Plate() { Name = "Abbey Road", PublishingYear = 1969, CoastPrice = 200, SalePrice = pl2.CoastPrice + 100, 
                BandId = band1.Id, PublisherId = pb2.Id, Tracks = new List<Track> { tr3, tr4 }, GenreId = gn1.Id });
            gn1 = context.Genres.Add(new Genre() { Name = "Rock-n-Roll", Plates = new List<Plate> { pl1, pl2 } });
            pb1 = context.Publishers.Add(new Publisher() { Name = "Jordan Feldstein's Career Artist Management", Plates = new List<Plate> { pl1 } });
            pb2 = context.Publishers.Add(new Publisher() { Name = "Derek Taylor", Plates = new List<Plate> { pl2 } });
            context.SaveChanges();

            //ACCOUNT TYPES
            var buyerAT = context.AccountTypes.Add(new Entities.AccountType() { Name = "Buyer" });
            var sellerAT = context.AccountTypes.Add(new Entities.AccountType() { Name = "Seller" });

            var acc1 = context.Accounts.Add(new Account() { Login = "Anna", Password = ComputeSha256Hash("12345"), AccountTypeId = buyerAT.Id, MoneyBalance = 1000, AmountOfPurchases = 300});
            var acc2 = context.Accounts.Add(new Account() { Login = "Mariia", Password = ComputeSha256Hash("54321"), AccountTypeId = buyerAT.Id, MoneyBalance = 500, AmountOfPurchases = 0});
            var acc3 = context.Accounts.Add(new Account() { Login = "admin", Password = ComputeSha256Hash("admin"), AccountTypeId = sellerAT.Id});

            context.SaveChanges();
        }
    }
    
}

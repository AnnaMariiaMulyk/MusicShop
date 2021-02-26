using DAL2._0;
using DAL2._0.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace UI
{
    class Program
    {
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

        static void Main(string[] args)
        {
            int menuChoise = 0;
            DALService dalService = new DALService();
            Console.WriteLine("-----LOGIN-----");
            Console.WriteLine("1. Sign in");
            Console.WriteLine("2. Sign up");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter choise: ");
            try
            {
                menuChoise = int.Parse(Console.ReadLine());
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            switch(menuChoise)
            {
                case 1:
                    {
                        string login;
                        string password;
                        Account account = new Account();
                        Console.Clear();
                        Console.WriteLine("Enter login: ");
                        login = Console.ReadLine();
                        Console.WriteLine("Enter password: ");
                        password = Console.ReadLine();
                        try
                        {
                            account = dalService.GetAccount(login, password);
                        }
                        catch(ArgumentNullException e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine("-----MENU-----");
                        Console.WriteLine("1. Search plate");
                        Console.WriteLine("2. Change login");
                        Console.WriteLine("3. Change password");
                        Console.WriteLine("4. Exit");
                        Console.WriteLine("Enter choise: ");
                        int choiseMenu = int.Parse(Console.ReadLine());
                        switch (choiseMenu)
                        {
                            case 1:
                                {
                                    Console.Clear();

                                    Console.WriteLine("-----SEARCH PLATE-----");
                                    Console.WriteLine("1. By name");
                                    Console.WriteLine("2. By band ");
                                    Console.WriteLine("3. By genre");
                                    Console.WriteLine("4. Exit");
                                    Console.WriteLine("Enter choise: ");
                                    choiseMenu = int.Parse(Console.ReadLine());
                                    switch (choiseMenu)
                                    {
                                        case 1:
                                            {
                                                string plateName;
                                                Console.Clear();
                                                Console.WriteLine("Enter name of plate: ");
                                                plateName = Console.ReadLine();
                                                IQueryable<Plate> plates = dalService.FindPlateByName(plateName);
                                                if (plates == null) { break; }
                                                foreach (var p in plates)
                                                {
                                                    string buyChoise;
                                                    Console.WriteLine("Name: " + p.Name);
                                                    Console.WriteLine("Band name: " + p.Band.Name);
                                                    Console.WriteLine("Price: " + p.SalePrice);
                                                    Console.WriteLine();
                                                    Console.WriteLine("Do you want to buy the plate?");
                                                    Console.WriteLine("Enter yes ot no: ");
                                                    buyChoise = Console.ReadLine();
                                                    if (buyChoise == "yes")
                                                    {
                                                        dalService.SellPlate(p.Id, account.Id);
                                                    }

                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                string plateBand;
                                                Console.Clear();
                                                Console.WriteLine("Enter name of band: ");
                                                plateBand = Console.ReadLine();
                                                List<Plate> plates = (List<Plate>)dalService.FindPlateByBand(plateBand);
                                                if (plates == null) { break; }
                                                foreach (var p in plates)
                                                {
                                                    string buyChoise;
                                                    Console.WriteLine("Name: " + p.Name);
                                                    Console.WriteLine("Band name: " + p.Band.Name);
                                                    Console.WriteLine("Price: " + p.SalePrice);
                                                    Console.WriteLine();
                                                    Console.WriteLine("Do you want to buy the plate?");
                                                    Console.WriteLine("Enter yes ot no: ");
                                                    buyChoise = Console.ReadLine();
                                                    if (buyChoise == "yes")
                                                    {
                                                        dalService.SellPlate(p.Id, account.Id);
                                                    }
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                string plateGenre;
                                                Console.Clear();
                                                Console.WriteLine("Enter name of genre: ");
                                                plateGenre = Console.ReadLine();
                                                List<Plate> plates = (List<Plate>)dalService.FindPlateByGenre(plateGenre);
                                                if (plates == null) { break; }
                                                foreach (var p in plates)
                                                {
                                                    string buyChoise;
                                                    Console.WriteLine("Name: " + p.Name);
                                                    Console.WriteLine("Band name: " + p.Band.Name);
                                                    Console.WriteLine("Price: " + p.SalePrice);
                                                    Console.WriteLine();
                                                    Console.WriteLine("Do you want to buy the plate?");
                                                    Console.WriteLine("Enter yes ot no: ");
                                                    buyChoise = Console.ReadLine();
                                                    if (buyChoise == "yes")
                                                    {
                                                        dalService.SellPlate(p.Id, account.Id);
                                                    }
                                                }
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    
                                    Console.Clear();
                                    string newLogin;
                                    Console.WriteLine("Enter new login: ");
                                    newLogin = Console.ReadLine();
                                    dalService.ChangeLogin(account.Id, newLogin);
                                    break;
                                }
                            case 3:
                                {
                                    Console.Clear();
                                    string newPassword;
                                    Console.WriteLine("Enter new password: ");
                                    newPassword = Console.ReadLine();
                                    dalService.ChangePassword(account.Id, newPassword);
                                    break;
                                }
                            case 4:
                                {
                                    Console.Clear();
                                    Console.WriteLine("Goodbye!");
                                    Console.ReadKey();
                                    break;
                                }


                        }
                        break;
                    }
                case 2:
                    {

                        break;
                    }
                case 3:
                    {

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

    }
}

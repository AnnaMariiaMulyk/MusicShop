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
        static void Main(string[] args)
        {
            DALService dalService = new DALService();
            Console.WriteLine("-----BANDS-----");
            foreach(Band b in dalService.GetAllBands())
            {
                Console.WriteLine(b.Name);
            }
        }

    }
}

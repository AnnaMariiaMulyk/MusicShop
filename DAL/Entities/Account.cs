using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int AccountTypeId { get; set; }
        public virtual AccountType AccountType { get; set; }

    }
}

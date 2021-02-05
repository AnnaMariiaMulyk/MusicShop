using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class AccountType
    {
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DataAccess.Models.Events
{
    public partial class Users
    {
        public Users()
        {
            Transactions = new HashSet<Transactions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }

        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}

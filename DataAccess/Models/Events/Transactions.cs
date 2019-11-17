using System;
using System.Collections.Generic;

namespace DataAccess.Models.Events
{
    public partial class Transactions
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TransactionReference { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public virtual Users User { get; set; }
    }
}

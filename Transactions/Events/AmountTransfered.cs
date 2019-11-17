using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Transactions.Events
{
   public class AmountTransfered : INotification
    {
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public decimal Amount { get; set; }
    }
}

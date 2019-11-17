using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models.Events;
namespace Transactions.Queries
{
    public class GetTransactions : IRequest<List<GetTransactionResult>>
    {
        public int userId { get; set; }
    }
    public class GetTransactionResult
    {
        public string TransactionReference { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string Description { get; set; }
        public DateTime Date
        {
            get; set;
        }
    }
}

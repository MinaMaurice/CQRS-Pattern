using DataAccess.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories.Events
{
    public class EFTransactionsRepository : ITransactionsRepository
    {

        private readonly HalalaHEventsContext dbContext;

        public EFTransactionsRepository(HalalaHEventsContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddTransaction(int FromUser, int ToUser, decimal Amount)
        {
           var transferFromUser =  dbContext.Users.Find(FromUser);
          string transactionReference =   GenerateTransactionReference();
            dbContext.Transactions.Add(new Transactions()
            {
                Date = DateTime.UtcNow.Date,
                TransactionReference = transactionReference,
                Type = "Credit",
                UserId = FromUser,
                Description = "TopUp",
                Amount = transferFromUser.Balance,
                Balance = transferFromUser.Balance
            });
            dbContext.Transactions.Add(new Transactions()
            {
                Date = DateTime.UtcNow.Date,
                TransactionReference = transactionReference,
                Type = "Debit",
                UserId = FromUser,
                Description = "Transfer to " + ToUser,
                Amount = Amount,
                Balance = transferFromUser.Balance - Amount
            });
            var transferToUser = dbContext.Users.Find(ToUser);

            dbContext.Transactions.Add(new Transactions()
            {
                Date = DateTime.UtcNow.Date,
                TransactionReference = transactionReference,
                Type = "Credit",
                UserId = ToUser,
                Description = "Received from " + FromUser,
                Amount = Amount,
                Balance = transferToUser.Balance + Amount
            });
        }

        public List<Transactions> GetTransactions(int userId)
        {
          return  dbContext.Transactions.Where(e => e.UserId == userId).ToList();
        }
        private string GenerateTransactionReference()
        {
            Random _random = new Random();
            return string.Format("Trx-{0}", _random.Next(9999));
        }
    }
}

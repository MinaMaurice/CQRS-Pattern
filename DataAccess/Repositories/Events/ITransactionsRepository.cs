using DataAccess.Models.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Events
{
  public interface ITransactionsRepository
    {
        void AddTransaction(int FromUser, int ToUser, decimal Amount);
        List<Transactions> GetTransactions(int userId);

    }
}

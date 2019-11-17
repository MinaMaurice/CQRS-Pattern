using DataAccess.Repositories.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Events.Repositories
{
   public interface IDataStore
    {
        ITransactionsRepository transactions { get; }
        IUsersRepository users { get; }
        void CommitChanges();
    }
}

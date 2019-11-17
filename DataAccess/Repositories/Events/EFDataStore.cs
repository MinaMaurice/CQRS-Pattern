using DataAccess.Models.Events;
using DataAccess.Repositories.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Events.Repositories
{
   public class EFDataStore : IDataStore
    {
        private readonly HalalaHEventsContext dbContext;
        private readonly IUsersRepository usersRepository;
        private readonly ITransactionsRepository transactionsRepository;
        public IUsersRepository users => usersRepository;
        public ITransactionsRepository transactions => transactionsRepository;
        public EFDataStore(HalalaHEventsContext dbContext)
        {
            this.dbContext = dbContext;
            this.usersRepository = new EFUsersRepository(this.dbContext);
            this.transactionsRepository = new EFTransactionsRepository(this.dbContext);

        }
        public void CommitChanges()
        {
            dbContext.SaveChanges();
        }
    }
}

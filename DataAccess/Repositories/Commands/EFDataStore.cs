using DataAccess.Domain.Commands;
using DataAccess.Repositories.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Commands.Repositories
{
   public class EFDataStore : IDataStore
    {
        private readonly HalalaHContext dbContext;
        private readonly IUsersRepository usersRepository;

        public IUsersRepository users => usersRepository;

        public EFDataStore(HalalaHContext dbContext)
        {
            this.dbContext = dbContext;
            this.usersRepository = new EFUsersRepository(this.dbContext);
        }
      public void CommitChanges()
        {
            dbContext.SaveChanges();
        }
    }
}

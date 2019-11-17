using DataAccess.Repositories.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commands.Repositories
{
   public interface IDataStore
    {
        IUsersRepository users { get; }
        void CommitChanges();
    }
}

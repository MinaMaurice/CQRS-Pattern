using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Events
{
  public interface IUsersRepository
    {
        void UpdateAmounts(int FromUser, int ToUser, decimal Amount);
    }
}

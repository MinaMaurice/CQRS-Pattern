using DataAccess.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Commands
{
  public interface IUsersRepository
    {
        bool MakeTransfer(int FromUser, int ToUser, decimal Amount);

    }
}

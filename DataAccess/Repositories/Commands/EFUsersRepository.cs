using DataAccess.Domain.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories.Commands
{
    public class EFUsersRepository : IUsersRepository
    {
        private readonly HalalaHContext dbContext;

        public EFUsersRepository(HalalaHContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool MakeTransfer(int FromUser ,int ToUser , decimal Amount )
        {
            SqlParameter fromUser = new SqlParameter("@FromUser", FromUser);
            fromUser.Direction = ParameterDirection.Input;

            SqlParameter toUser = new SqlParameter("@ToUser", ToUser);
            toUser.Direction = ParameterDirection.Input;
         

            SqlParameter amount = new SqlParameter("@Amount", Amount);
            amount.Direction = ParameterDirection.Input;

            SqlParameter result = new SqlParameter("@result ", SqlDbType.Bit);
            result.Direction = ParameterDirection.Output;

            dbContext.Database.ExecuteSqlCommand("[MakeTransfer] @FromUser , @ToUser, @Amount , @result OUT", fromUser, toUser, amount, result);

            return (bool)result.Value;
        }

    }
}

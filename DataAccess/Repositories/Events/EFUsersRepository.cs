using DataAccess.Models.Events;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Repositories.Events
{
    public class EFUsersRepository : IUsersRepository
    {
        private readonly HalalaHEventsContext dbContext;

        public EFUsersRepository(HalalaHEventsContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void  UpdateAmounts(int FromUser ,int ToUser , decimal Amount )
        {
            SqlParameter fromUser = new SqlParameter("@FromUser", FromUser);
            fromUser.Direction = ParameterDirection.Input;

            SqlParameter toUser = new SqlParameter("@ToUser", ToUser);
            toUser.Direction = ParameterDirection.Input;
         

            SqlParameter amount = new SqlParameter("@Amount", Amount);
            amount.Direction = ParameterDirection.Input;

            dbContext.Database.ExecuteSqlCommand("[UpdateAmounts] @FromUser , @ToUser, @Amount", fromUser, toUser, amount);
        }
    }
}

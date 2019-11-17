using DataAccess.Events.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Transactions.Events
{
    public class AmountTransferedProjectionsHandler : INotificationHandler<AmountTransfered>
    {
        private readonly IDataStore dataStore;

        public AmountTransferedProjectionsHandler(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }
        public Task Handle(AmountTransfered @event, CancellationToken cancellationToken)
        {
            dataStore.transactions.AddTransaction(@event.FromUserId, @event.ToUserId, @event.Amount);
            dataStore.CommitChanges();
            dataStore.users.UpdateAmounts(@event.FromUserId, @event.ToUserId, @event.Amount);
            
            return Task.CompletedTask;
        }
    }
}

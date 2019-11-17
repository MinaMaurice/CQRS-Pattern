using DataAccess.Commands.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Transactions.Events;

namespace Transactions.Commands
{
 public class MakeTransferHandler : IRequestHandler<MakeTransfer, bool>
    {
        private readonly IDataStore dataStore;
        private readonly IMediator mediator;

        public MakeTransferHandler(IDataStore dataStore, IMediator mediator)
        {
            this.dataStore = dataStore;
            this.mediator = mediator;
        }
        public async Task<bool> Handle(MakeTransfer command, CancellationToken cancellationToken)
        {
            var result =  dataStore.users.MakeTransfer(command.FromUserId,command.ToUserId,command.Amount);
            if(result)
            {
                await mediator.Publish(new AmountTransfered() {FromUserId = command.FromUserId,ToUserId = command.ToUserId , Amount=command.Amount });
            }
            return result;
        }
    }
}

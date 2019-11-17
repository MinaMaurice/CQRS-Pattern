using DataAccess.Events.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Transactions.Queries
{
    public class GetTransactionsHandler : IRequestHandler<GetTransactions, List<GetTransactionResult>>
    {
        private readonly IDataStore dataStore;

        public GetTransactionsHandler(IDataStore dataStore, IMediator mediator)
        {
            this.dataStore = dataStore;
        }
        public Task<List<GetTransactionResult>> Handle(GetTransactions request, CancellationToken cancellationToken)
        {
            var transactions =   dataStore.transactions.GetTransactions(request.userId);
            List<GetTransactionResult> result = new List<GetTransactionResult>();
            foreach (var item in transactions)
            {
                result.Add(new GetTransactionResult() {
                    TransactionReference = item.TransactionReference,
                    Type = item.Type,
                    Amount = item.Amount,
                    Balance = item.Balance,
                    Description = item.Description,
                    Date = item.Date
                });
            }
            return Task.FromResult(result);

        }
    }
}

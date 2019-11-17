using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Transactions.Commands
{
  public class MakeTransfer : IRequest<bool>
    {
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public decimal Amount { get; set; }

    }
}

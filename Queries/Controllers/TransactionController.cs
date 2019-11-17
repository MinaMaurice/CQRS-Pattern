using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transactions.Queries;

namespace Queries.Controllers
{
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator mediator;
        public TransactionController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("v1/User/{UserId}/transactions")]
        public async Task<IActionResult> Transactions(int UserId)
        {
            var result = await mediator.Send(new GetTransactions() {userId = UserId });
            return Ok(result);
        }

    }
}

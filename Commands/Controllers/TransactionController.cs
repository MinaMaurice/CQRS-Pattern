using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transactions.Commands;

namespace Commands.Controllers
{
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator mediator;
        public TransactionController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("v1/CommitTransaction")]
        public async Task<IActionResult> CommitTransaction([FromBody] MakeTransfer model)
        {
            var result = await mediator.Send(model); 
            return result ? new StatusCodeResult(200) : new StatusCodeResult(400);
        }
    }
}


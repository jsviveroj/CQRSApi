﻿using CQRS_Example.Config;
using Domain.Commands;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRS_Example.Controllers
{
    public class CustomerController : ApiControllerBase
    {
        public CustomerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("GetCustomerById")]
        public async Task<ActionResult> GetCustomerById([FromQuery] int customerId)
        {
            var query = new GetCustomerQuery(customerId);
            return Ok(await QueryAsync(query));
        }


        [HttpPost("CreateCustomer")]
        public async Task<ActionResult> CreateCustomer([FromBody] AddCustomerCommand command)
            => Ok(await CommandAsync(command));
    }
}

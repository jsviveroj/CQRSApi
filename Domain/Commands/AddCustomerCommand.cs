using Domain.DTOs.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands
{
    public class AddCustomerCommand : IRequest<CustomerDTO>
    {
        public string Name { get; set;}
        public string Phone { get; set;}
    }
}

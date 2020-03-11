using AutoMapper;
using Domain.Commands;
using Domain.DTOs.Customer;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Handlers
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, CustomerDTO>
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public AddCustomerHandler(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> Handle(AddCustomerCommand request, CancellationToken cToken)
        {
            var customer = new Customer 
            {  
                Name = request.Name,
                Phone = request.Phone 
            };

            var createdCustomer = await _repo.PostAsync(customer);

            return _mapper.Map<CustomerDTO>(createdCustomer);
            
        }
    }
}

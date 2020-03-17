using Domain.Commands;
using Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Handlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {

        private readonly ICustomerRepository _repo;

        public DeleteCustomerHandler(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repo.GetAsync(c => c.Id == request.CustomerId);

            if(customer == null)
                throw new Exception("Customer doesn't exist");

            return await _repo.DeleteAsync(customer);
        }
    }
}

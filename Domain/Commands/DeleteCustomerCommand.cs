using MediatR;

namespace Domain.Commands
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public long CustomerId { get; set; }
    }
}

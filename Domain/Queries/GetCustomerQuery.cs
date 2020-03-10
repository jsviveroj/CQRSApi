using Domain.DTOs.Customer;
using MediatR;

namespace Domain.Queries
{
    public class GetCustomerQuery : IRequest<CustomerDTO>
    {
        public GetCustomerQuery(long customerId)
        {
            Id = customerId;
        }

        public long Id { get;}
    }
}

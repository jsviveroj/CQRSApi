using AutoMapper;
using Domain.DTOs.Customer;
using Domain.Queries;
using Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Handlers
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, CustomerDTO>
    {
        private readonly ICustomerRepository _repo;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetCustomerHandler(IMediator mediator, ICustomerRepository repo, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<CustomerDTO> Handle(GetCustomerQuery request, CancellationToken cToken)
        {
            var customer = await _repo.GetAsync(c => c.Id == request.Id);

            if (customer == null)
                return null;

            var dto = _mapper.Map<CustomerDTO>(customer);
            return dto;
        }
    }
}

using AutoMapper;
using Domain.DTOs.Customer;
using Domain.Entities;

namespace Domain.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>();
        }
    }
}

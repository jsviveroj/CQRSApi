using Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetAsync(Expression<Func<Customer, bool>> predicate);
        Task<Customer> PostAsync(Customer customer);
        Task<bool> DeleteAsync(Customer customer);
    }
}

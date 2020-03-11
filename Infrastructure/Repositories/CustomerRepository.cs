using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private CQRSContext _context;

        public CustomerRepository(CQRSContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetAsync(Expression<Func<Customer, bool>> predicate)
            => await _context.Customer.Where(predicate).FirstOrDefaultAsync();

        public async Task<Customer> PostAsync(Customer customer)
        {
            var createdCustomer = await _context.Customer.AddAsync(customer);

            if (_context.SaveChanges() == 0)
                throw new Exception("SQL exception, couldn't save customer");
            
            return createdCustomer.Entity;
        }
    }
}

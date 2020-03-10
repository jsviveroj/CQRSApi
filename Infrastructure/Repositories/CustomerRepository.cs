using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
    }
}

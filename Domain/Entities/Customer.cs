using System.Collections.Generic;

namespace Domain.Entities
{
    public class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}

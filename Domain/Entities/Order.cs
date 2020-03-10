using System;

namespace Domain.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Guid OrderGuid { get; set; }
        public long CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Data.Access.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderId { get; set; }
        public int? LocationId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal? Total { get; set; }
        public int? Quantity { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}

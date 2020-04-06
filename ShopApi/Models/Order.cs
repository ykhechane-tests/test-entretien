using System;
using System.Collections.Generic;

namespace ShopApi.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}

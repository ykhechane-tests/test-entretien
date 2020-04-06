using System;
using System.Collections.Generic;

namespace ShopApi.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}

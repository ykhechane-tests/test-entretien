using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ShopApi.Models
{ 
    public partial class Product
    {      
        public Product( )
        {
            OrderItem = new HashSet<OrderItem>();
        }
       
        public string Name { get; set; }
        public int Price { get; set; }         
        public int Stock { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int Id { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }       
    }
}

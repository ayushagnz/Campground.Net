using System;
using System.Collections.Generic;

namespace SD6503Assignment3.Models
{
    public partial class Product
    {
        public Product()
        {
            Order = new HashSet<Order>();
        }

        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public int? Rating { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}

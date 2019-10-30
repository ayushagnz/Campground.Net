using System;
using System.Collections.Generic;

namespace SD6503Assignment3.Models
{
    public partial class Order
    {
        public int Oid { get; set; }
        public int Cid { get; set; }
        public string ProductId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime PaymentDate { get; set; }

        public virtual Customer C { get; set; }
        public virtual Product Product { get; set; }
    }
}

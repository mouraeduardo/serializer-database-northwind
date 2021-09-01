using System;
using System.Collections.Generic;

#nullable disable

namespace agoravai.Models
{
    public partial class OrderDetail
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public byte[] UnitPrice { get; set; }
        public long Quantity { get; set; }
        public double Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

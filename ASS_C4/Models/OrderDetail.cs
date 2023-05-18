using System;
using System.Security.Permissions;

namespace ASS_C4.Models
{
    public class OrderDetail
    {
        public Guid IdOrderDetail { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int NotionalPrice { get; set; }
        public int Discount { get; set; }
        public int Size { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Orders { get; set; }

    }
}

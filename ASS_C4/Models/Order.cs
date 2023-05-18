using System;
using System.Collections;
using System.Collections.Generic;

namespace ASS_C4.Models
{
    public class Order
    {
        public Guid IdOrder { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public int TotalPrice { get; set; }
        public int Vat { get; set; }
        public bool Status { get; set; }
        public int PaymentId { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Payment Payments { get; set; }
    }
}

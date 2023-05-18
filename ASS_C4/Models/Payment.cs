using System.Collections.Generic;

namespace ASS_C4.Models
{
    public class Payment
    {
        public int IdPayment { get; set; }
        public string NamePayment { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}

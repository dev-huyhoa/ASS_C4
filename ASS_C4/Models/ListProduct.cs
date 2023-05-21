using System;
using System.Security.Permissions;

namespace ASS_C4.Models
{
    public class ListProduct
    {
        public Guid IdListProduct { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}

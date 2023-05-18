using System;

namespace ASS_C4.Models
{
    public class Customer
    {
        public Guid IdCustomer { get; set; }
        public string NameCustomer { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public long Birthday { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }

    }
}

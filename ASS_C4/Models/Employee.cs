using System;
using System.Collections.Generic;

namespace ASS_C4.Models
{
    public class Employee
    {
        public Guid IdEmployee { get; set; }
        public string NameEmployee { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public long Birthday { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public bool IsOnline { get; set; }
        public bool IsActice { get; set; }
        public bool IsDelete { get; set; }
        public int RoleId { get; set; }

        public virtual Role Roles { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace ASS_C4.Models
{
    public class Role
    {
        public int IdRole { get; set; }
        public string NameRole { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

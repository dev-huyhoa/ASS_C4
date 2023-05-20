using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ASS_C4.Models
{
    public class Category
    {
        public Guid IdCategory { get; set; }
        public string NameCategory { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

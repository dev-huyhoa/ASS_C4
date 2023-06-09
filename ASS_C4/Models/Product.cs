﻿using System;

namespace ASS_C4.Models
{
    public class Product
    {
        public Guid IdProduct { get; set; }
        public string NameProduct { get; set; }
        public int Price { get; set; }
        public int PricePromotion { get; set; }
        public string Image { get; set; }
        public string Decription { get; set; }

        public long ModifyDate { get; set; }
        public bool IsDelete { get; set; }
        public bool Status { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Categories { get; set; }
    }
}

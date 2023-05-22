using ASS_C4.Models;
using System;

namespace ASS_C4.Areas.Admin.ViewModel
{
    public class ProductViewModel
    {
        public Guid IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string NameCategory { get; set; }

        public int Size { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int PricePromotion { get; set; }
        public string Image { get; set; }
        public string Decription { get; set; }

        public long ModifyDate { get; set; }
        public bool IsDelete { get; set; }
        public bool Status { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }

    }
}

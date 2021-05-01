using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Cart
    {
        public Cart()
        {
            LineItems = new List<LineItem>();
        }
        public IList<LineItem> LineItems { get; set; }
        public decimal TotalSum => LineItems.Sum(p => (p.Price * p.Quantity) - p.DiscountAmount);
        public decimal TotalDiscount => LineItems.Sum(p => p.DiscountAmount);
    }
}

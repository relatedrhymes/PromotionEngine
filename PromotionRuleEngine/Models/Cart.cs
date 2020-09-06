using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionRuleEngine.Models
{
    public class Cart
    {
        public List<CartItem> cartItems { get; set; }
        public int Total
        {
            get
            {
                return cartItems.Sum(i => i.Total);
            }
        }
    }
}

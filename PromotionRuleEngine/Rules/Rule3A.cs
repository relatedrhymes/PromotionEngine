using System;
using System.Collections.Generic;
using System.Linq;
using PromotionRuleEngine.Models;

namespace PromotionRuleEngine.Rules
{
    public class Rule3A : IRule
    {
        public bool IsApplicable(List<CartItem> items)
        {
            var item = items.Where(s => s.skuID == "A").FirstOrDefault();
            if (item.Quantity >= 3 && !item.IsPromotionApplied)
            {
                return true;
            }
            return false;
        }

        public List<CartItem> Apply(List<CartItem> items)
        {
            var item = items.Where(s => s.skuID == "A").FirstOrDefault();
            if (item != null)
            {
                int applicableItems = item.Quantity / 3;
                int notapplicableItems = item.Quantity % 3;
                int promotionalPrice = applicableItems * 130;
                int nonpromotionalprice = notapplicableItems * 50;
                int total = promotionalPrice + nonpromotionalprice;
                item.IsPromotionApplied = true;
                item.Total = total;
            }

            return items;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using PromotionRuleEngine.Models;

namespace PromotionRuleEngine.Rules
{
    public class Rule2B : IRule
    {
        public bool IsApplicable(List<CartItem> items)
        {
            var item = items.Where(s => s.skuID == "B").FirstOrDefault();
            if (item.Quantity >= 2 && !item.IsPromotionApplied)
            {
                return true;
            }
            return false;
        }

        public List<CartItem> Apply(List<CartItem> items)
        {
            var item = items.Where(s => s.skuID == "B").FirstOrDefault();
            if (item != null)
            {
                int applicableItems = item.Quantity / 2;
                int notapplicableItems = item.Quantity % 2;
                int promotionalPrice = applicableItems * 45;
                int nonpromotionalprice = notapplicableItems * 30;
                int total = promotionalPrice + nonpromotionalprice;
                item.IsPromotionApplied = true;
                item.Total = total;
            }

            return items;
        }
    }
}

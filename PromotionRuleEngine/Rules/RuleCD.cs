using System;
using System.Collections.Generic;
using System.Linq;
using PromotionRuleEngine.Models;

namespace PromotionRuleEngine.Rules
{
    public class RuleCD : IRule
    {
        public bool IsApplicable(List<CartItem> items)
        {
            var itemC = items.Where(s => s.skuID == "C").FirstOrDefault();
            var itemD = items.Where(s => s.skuID == "D").FirstOrDefault();

            if(itemC != null && itemD != null)
            {
                if (itemC.Quantity >= 1 && !itemC.IsPromotionApplied && itemD.Quantity >= 1 && !itemD.IsPromotionApplied)
                {
                    return true;
                }
            }

            return false;
        }

        public List<CartItem> Apply(List<CartItem> items)
        {
            var itemC = items.Where(s => s.skuID == "C").FirstOrDefault();
            var itemD = items.Where(s => s.skuID == "D").FirstOrDefault();

            if (itemC != null && itemD != null)
            {
                if (itemC.Quantity == itemD.Quantity)
                {
                    itemD.Total = itemD.Quantity * 30;
                }
                else if (itemC.Quantity > itemD.Quantity)
                {
                    int nonpromotionalprice = (itemC.Quantity - itemD.Quantity) * 20;
                    int promotionalPrice = itemD.Quantity * 30;
                    itemC.Total = nonpromotionalprice;
                    itemD.Total = promotionalPrice;
                }
                else
                {
                    int nonpromotionalprice = (itemD.Quantity - itemC.Quantity) * 15;
                    int promotionalPrice = itemC.Quantity * 30;
                    itemD.Total = nonpromotionalprice;
                    itemC.Total = promotionalPrice;
                }

                itemC.IsPromotionApplied = true;
                itemD.IsPromotionApplied = true;
            }

            return items;
        }
    }
}

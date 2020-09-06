using System;
using System.Collections.Generic;
using PromotionRuleEngine.Models;

namespace PromotionRuleEngine.Rules
{
    public interface IRule
    {
        bool IsApplicable(List<CartItem> items);
        List<CartItem> Apply(List<CartItem> items);
    }
}

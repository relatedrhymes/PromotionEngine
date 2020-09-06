using System;
using System.Collections.Generic;
using PromotionRuleEngine.Models;
using PromotionRuleEngine.Rules;

namespace PromotionRuleEngine
{
    public class PromotionEngine
    {
        private List<SKU> _skuList;
        private List<IRule> _rules;

        public PromotionEngine()
        {
            InitiateSKUListAndRules();
        }

        public Cart RunPromotionEngine(Cart cart)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsApplicable(cart.cartItems))
                    cart.cartItems = rule.Apply(cart.cartItems);
            }

            return cart;
        }

        public void DisplayResults(Cart cart)
        {
            foreach (var item in cart.cartItems)
            {
                Console.WriteLine(item.skuID + " " + item.Quantity + " " + item.Total + " " + item.IsPromotionApplied);
            }
            Console.WriteLine("--------------------------");
            Console.WriteLine("Total            " + cart.Total);
        }

        public List<SKU> GetSKUs()
        {
            return _skuList;
        }

        public Cart InitializeCart()
        {
            Cart cart = new Cart();
            cart.cartItems = new List<CartItem>()
            {
                new CartItem(_skuList) { skuID="A", Quantity = 2 },
                new CartItem(_skuList) { skuID="B", Quantity = 1 },
                new CartItem(_skuList) { skuID="C", Quantity = 2 },
                new CartItem(_skuList) { skuID="D", Quantity = 3 }
            };

            return cart;
        }

        private void InitiateSKUListAndRules()
        {
            _skuList = new List<SKU>()
            {
                new SKU{ ID="A", Price = 50},
                new SKU{ ID="B", Price = 30},
                new SKU{ ID="C", Price = 20},
                new SKU{ ID="D", Price = 15}
            };

            _rules = new List<IRule>()
            {
                new Rule3A(),
                new Rule2B(),
                new RuleCD()
            };
        }
    }
}

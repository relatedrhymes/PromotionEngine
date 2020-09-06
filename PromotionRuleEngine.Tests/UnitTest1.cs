using System;
using System.Collections.Generic;
using PromotionRuleEngine.Models;
using Xunit;

namespace PromotionRuleEngine.Tests
{
    public class UnitTest1
    {
        private readonly PromotionEngine _engine;
        public UnitTest1()
        {
            _engine = new PromotionEngine();
        }
        [Fact]
        public void Scenario1()
        {
            Cart cart = new Cart()
            {
                cartItems = new List<CartItem>()
                {
                    new CartItem(_engine.GetSKUs()) { skuID="A", Quantity = 1 },
                    new CartItem(_engine.GetSKUs()) { skuID="B", Quantity = 1 },
                    new CartItem(_engine.GetSKUs()) { skuID="C", Quantity = 1 },
                }
            };

            cart = _engine.RunPromotionEngine(cart);
            Assert.Equal(100, cart.Total);
        }

        [Fact]
        public void Scenario2()
        {
            Cart cart = new Cart()
            {
                cartItems = new List<CartItem>()
                {
                    new CartItem(_engine.GetSKUs()) { skuID="A", Quantity = 5 },
                    new CartItem(_engine.GetSKUs()) { skuID="B", Quantity = 5 },
                    new CartItem(_engine.GetSKUs()) { skuID="C", Quantity = 1 },
                }
            };

            cart = _engine.RunPromotionEngine(cart);
            Assert.Equal(370, cart.Total);
        }

        [Fact]
        public void Scenario3()
        {
            Cart cart = new Cart()
            {
                cartItems = new List<CartItem>()
                {
                    new CartItem(_engine.GetSKUs()) { skuID="A", Quantity = 3 },
                    new CartItem(_engine.GetSKUs()) { skuID="B", Quantity = 5 },
                    new CartItem(_engine.GetSKUs()) { skuID="C", Quantity = 1 },
                    new CartItem(_engine.GetSKUs()) { skuID="D", Quantity = 1 }
                }
            };

            cart = _engine.RunPromotionEngine(cart);
            Assert.Equal(280, cart.Total);
        }
    }
}

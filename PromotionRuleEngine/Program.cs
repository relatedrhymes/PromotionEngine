using System;
using System.Collections.Generic;
using PromotionRuleEngine.Models;
using PromotionRuleEngine.Rules;

namespace PromotionRuleEngine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PromotionEngine engine = new PromotionEngine();
            Cart cart = engine.InitializeCart();
            cart = engine.RunPromotionEngine(cart);
            engine.DisplayResults(cart);
            Console.ReadLine();
        }
    }
}

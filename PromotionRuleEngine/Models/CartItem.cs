using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionRuleEngine.Models
{
    public class CartItem
    {
        private readonly List<SKU> _listSKU;
        public CartItem(List<SKU> listSKU)
        {
            _listSKU = listSKU;
        }
        public string skuID { get; set; }
        public int Quantity { get; set; }
        public bool IsPromotionApplied { get; set; }
        private int _total;
        public int Total
        {
            get
            {
                var sku = _listSKU.Where(s => s.ID == skuID).FirstOrDefault();
                return IsPromotionApplied ? _total : sku.Price * Quantity;
            }
            set
            {
                _total = value;
            }
        }
    }
}

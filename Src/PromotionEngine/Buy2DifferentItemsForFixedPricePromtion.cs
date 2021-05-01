using System.Linq;
using Models;

namespace PromotionEngine
{
    public class Buy2DifferentItemsForFixedPricePromtion : IPromotion
    {
        private string itemNumberA;
        private string itemNumberB;
        private decimal fixedPrice;

        public Buy2DifferentItemsForFixedPricePromtion(string itemNumberA, string itemNumberB, decimal fixedPrice)
        {
            this.itemNumberA = itemNumberA;
            this.itemNumberB = itemNumberB;
            this.fixedPrice = fixedPrice;
        }

        public bool IsDiscountValidForCart(Cart cart)
        {
            if (cart.LineItems.Any(p => p.ArticleNumber == itemNumberA && p.NumberOfDiscounts < p.Quantity))
            {
                return cart.LineItems.Any(p => p.ArticleNumber == itemNumberB && p.NumberOfDiscounts < p.Quantity);
            }

            return false;
        }

        public void AddDiscountToCart(Cart cart)
        {
            if (IsDiscountValidForCart(cart))
            {
                var lineItemA = cart.LineItems.Single(p => p.ArticleNumber == itemNumberA);
                var lineItemB = cart.LineItems.Single(p => p.ArticleNumber == itemNumberB);
                lineItemA.DiscountAmount += lineItemA.Price - fixedPrice / 2;
                lineItemB.DiscountAmount += lineItemB.Price - fixedPrice / 2;
                lineItemB.NumberOfDiscounts += 1;
                lineItemA.NumberOfDiscounts += 1;
            }
        }
    }
}

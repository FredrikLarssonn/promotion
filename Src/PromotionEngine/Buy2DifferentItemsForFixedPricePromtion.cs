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
            //if (cart.LineItems.Any(p => p.ArticleNumber == itemNumber && numberOfItems <= p.Quantity))
            //{
            //    var lineItem = cart.LineItems.Single(p => p.ArticleNumber == itemNumber);
            //    return (lineItem.Quantity - lineItem.NumberOfDiscounts) >= numberOfItems;
            //}

            return false;
        }

        public void AddDiscountToCart(Cart cart)
        {
            if (IsDiscountValidForCart(cart))
            {
                var lineItem = cart.LineItems.Single(p => p.ArticleNumber == itemNumberA);
                //lineItem.DiscountAmount += (lineItem.Price * numberOfItems) - fixedPrice;
                lineItem.NumberOfDiscounts += 1;
            }
        }
    }
}

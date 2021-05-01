using System.Linq;
using Models;

namespace PromotionEngine
{
    public class BuyXItemsForFixedPricePromtion : IPromotion
    {
        private string itemNumber;
        private decimal fixedPrice;
        private int numberOfItems;

        public BuyXItemsForFixedPricePromtion(string itemNumber, decimal fixedPrice, int numberOfItems)
        {
            this.itemNumber = itemNumber;
            this.fixedPrice = fixedPrice;
            this.numberOfItems = numberOfItems;
        }

        public bool IsDiscountValidForCart(Cart cart)
        {
            if (cart.LineItems.Any(p => p.ArticleNumber == itemNumber && numberOfItems <= p.Quantity))
            {
                var lineItem = cart.LineItems.Single(p => p.ArticleNumber == itemNumber);
                return (lineItem.Quantity - lineItem.NumberOfDiscounts) >= numberOfItems;
            }

            return false;
        }

        public void AddDiscountToCart(Cart cart)
        {
            if (IsDiscountValidForCart(cart))
            {
                var lineItem = cart.LineItems.Single(p => p.ArticleNumber == itemNumber);
                lineItem.DiscountAmount += (lineItem.Price * numberOfItems) - fixedPrice;
                lineItem.NumberOfDiscounts += numberOfItems;
            }
        }
    }
}

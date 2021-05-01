using System.Collections.Generic;
using System.Linq;
using Models;

namespace PromotionEngine
{
    public static class CartExtensions
    {
        public static void AddDiscountsToCart(this Cart cart, IList<IPromotion> promotions)
        {
            do
            {
                foreach (var promo in promotions)
                {
                    promo.AddDiscountToCart(cart);
                }
            } while (promotions.Any(p => p.IsDiscountValidForCart(cart)));
        }
    }
}

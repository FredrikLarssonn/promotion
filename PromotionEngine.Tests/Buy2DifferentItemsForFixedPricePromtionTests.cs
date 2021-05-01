using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Models;

namespace PromotionEngine.Tests
{
    [TestClass]
    public class Buy2DifferentItemsForFixedPricePromtionTests
    {
        private static IList<IPromotion> promotions = new List<IPromotion>
        {
            new BuyXItemsForFixedPricePromtion("A", 130, 3),
            new BuyXItemsForFixedPricePromtion("B", 45, 2),
            new Buy2DifferentItemsForFixedPricePromtion("C", "D", 30)
        };

        [TestMethod]
        public void A_And_B_For_30_IsDiscountValidForCart()
        {
            //Arrange
            var promo = promotions.Last();
            var cart = new Cart
            {
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        Quantity = 1,
                        ArticleNumber = "C",
                        Price = 20
                    },
                    new LineItem
                    {
                        Quantity = 1,
                        ArticleNumber = "D",
                        Price = 15
                    },
                }
            };

            //Act

            var isDiscountValidForCart = promo.IsDiscountValidForCart(cart);

            //assert
            Assert.AreEqual(true, isDiscountValidForCart);
        }
    }
}

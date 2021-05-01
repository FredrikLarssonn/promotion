using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Models;

namespace PromotionEngine.Tests
{
    [TestClass]
    public class BuyXItemsForFixedPriceTests
    {
        private static IList<IPromotion> promotions = new List<IPromotion>
        {
            new BuyXItemsForFixedPricePromtion("A", 130, 3),
            new BuyXItemsForFixedPricePromtion("B", 45, 2)
        };

        [TestMethod]
        public void Three_A_For_130_IsDiscountValidForCart()
        {
            //Arrange
            var promo = promotions.First();
            var cart = new Cart
            {
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        Quantity = 3,
                        ArticleNumber = "A",
                        Price = 50
                    }
                }
            };

            //Act

            var isDiscountValidForCart = promo.IsDiscountValidForCart(cart);

            //assert
            Assert.AreEqual(true, isDiscountValidForCart);
        }

        [TestMethod]
        public void Three_A_For_130_IsDiscountValidForCart_False()
        {
            //Arrange
            var promo = promotions.First();
            var cart = new Cart
            {
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        Quantity = 2,
                        ArticleNumber = "A",
                        Price = 50
                    }
                }
            };

            //Act

            var isDiscountValidForCart = promo.IsDiscountValidForCart(cart);

            //assert
            Assert.AreEqual(false, isDiscountValidForCart);
        }

        [TestMethod]
        public void Three_A_For_130_CorrectAmount()
        {
            //Arrange
            var promo = promotions.First();
            var cart = new Cart
            {
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        Quantity = 3,
                        ArticleNumber = "A",
                        Price = 50
                    }
                }
            };

            //Act

            promo.AddDiscountToCart(cart);

            //assert
            Assert.AreEqual(130m,cart.TotalSum);
        }

        [TestMethod]
        [Timeout(1000)]
        public void Test_Two_Promotions_Against_Cart()
        {

            //Arrange
            var cart = new Cart
            {
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        Quantity = 5,
                        ArticleNumber = "A",
                        Price = 50
                    },
                    new LineItem
                    {
                        Quantity = 5,
                        ArticleNumber = "B",
                        Price = 30
                    }
                }
            };

            //Act
            cart.AddDiscountsToCart(promotions);

            Assert.AreEqual(350, cart.TotalSum);
        }
    }
}

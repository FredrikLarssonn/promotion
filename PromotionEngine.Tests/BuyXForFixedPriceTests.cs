using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Models;

namespace PromotionEngine.Tests
{
    [TestClass]
    public class BuyXItemsForFixedPriceTests
    {
        [TestMethod]
        public void Three_A_For_130_IsDiscountValidForCart()
        {
            //Arrange
            var promo = new BuyXItemsForFixedPricePromtion("A", 130, 3);
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
            var promo = new BuyXItemsForFixedPricePromtion("A", 130, 3);
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
            var promo = new BuyXItemsForFixedPricePromtion("A", 130, 3);
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
    }
}

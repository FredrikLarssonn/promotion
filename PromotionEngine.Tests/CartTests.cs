using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Models;

namespace PromotionEngine.Tests
{
    [TestClass]
    public class CartTests
    {
        private static IList<IPromotion> promotions = new List<IPromotion>
        {
            new BuyXItemsForFixedPricePromtion("A", 130, 3),
            new BuyXItemsForFixedPricePromtion("B", 45, 2),
            new Buy2DifferentItemsForFixedPricePromtion("C", "D", 30)
        };

        [TestMethod]
        public void TestTotalSum()
        {
            //Arrange
            var promo = promotions.First();
            var cart = new Cart
            {
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        Quantity = 1,
                        ArticleNumber = "A",
                        Price = 50
                    },
                    new LineItem
                    {
                        Quantity = 1,
                        ArticleNumber = "B",
                        Price = 30
                    },
                    new LineItem
                    {
                        Quantity = 1,
                        ArticleNumber = "C",
                        Price = 20
                    },
                }
            };

            //Act
            cart.AddDiscountsToCart(promotions);

            //Assert
            Assert.AreEqual(100, cart.TotalSum);
        }
        

        [TestMethod]
        public void TestTotalSumWithAllItemsAndPromo()
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
                    },
                    new LineItem
                    {
                        Quantity = 1,
                        ArticleNumber = "C",
                        Price = 20
                    },
                }
            };

            //Act
            cart.AddDiscountsToCart(promotions);

            //Assert
            Assert.AreEqual(370, cart.TotalSum);
        }

        [TestMethod]
        public void TestTotalSumWithAllItemsAndPromo2()
        {
            //Arrange
            var cart = new Cart
            {
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        Quantity = 3,
                        ArticleNumber = "A",
                        Price = 50
                    },
                    new LineItem
                    {
                        Quantity = 5,
                        ArticleNumber = "B",
                        Price = 30
                    },
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
                    }
                }
            };

            //Act
            cart.AddDiscountsToCart(promotions);

            //Assert
            Assert.AreEqual(280, cart.TotalSum);
        }
    }
}

using Models;

namespace PromotionEngine
{
    public interface IPromotion
    {
        bool IsDiscountValidForCart(Cart cart);
        void AddDiscountToCart(Cart cart);
    }
}
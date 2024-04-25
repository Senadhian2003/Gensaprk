using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface CartItemServices
    {

        public CartItem AddCartItem(CartItem cartItem);
        public CartItem RemoveCartItem(CartItem cartItem);


    }
}

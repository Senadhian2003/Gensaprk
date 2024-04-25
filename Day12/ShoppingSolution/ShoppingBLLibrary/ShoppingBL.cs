//using ShoppingDALLibrary;
//using ShoppingModelLibrary;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ShoppingBLLibrary
//{
//    public class ShoppingBL
//    {
//        readonly ProductRepository productRepository;
//        readonly CustomerRepository customerRepository;
//        readonly CartItemRepository cartItemRepository;
//        readonly CartRepository cartRepository;
//        public ShoppingBL() {
//            productRepository = new ProductRepository();
//            customerRepository = new CustomerRepository();
//            cartItemRepository = new CartItemRepository();
//            cartRepository = new CartRepository();
//        }


//        public int AddToCart(Customer customer, int id)
//        {
//            Product product = productRepository.GetByKey(id);

//            if(product == null)
//            {
//                throw ElementNotFoundException("Product");

//            }

//            Console.WriteLine(product);
//            List<Cart> cartList = cartRepository.GetAll().ToList();

//            Cart cart;

//            cart = cartList.FirstOrDefault((c)=>c.CustomerId == customer.Id);

//            if(cart == null)
//            {
//                throw ElementNotFoundException("Cart");
//            }

//            CartItem cartItem = new CartItem(product,cart.Id);

//            cartItem = cartItemRepository.Add(cartItem);

           

//            if(cart.CartItems.Count ==5)
//            {
//                throw ListIsFullException("Cart");
//            }
            
//            cart.CartItems.Add(cartItem);


//            return 0;
//        }



//    }
//}

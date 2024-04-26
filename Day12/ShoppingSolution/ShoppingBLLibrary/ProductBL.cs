using ShoppingBLLibrary.Exceptions;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class ProductBL
    {
        readonly IRepository<int, Product> _repository;
        
        public ProductBL()
        {
            _repository = new ProductRepository();

        }

        public List<Product> GetProducts()
        {
            List<Product> products = _repository.GetAll().ToList();

            if (products != null)
            {
                return products;
            }

            throw new EmptyListException("Cart");

        }

        public Product GetProduct(int id)
        {
            Product product = _repository.GetByKey(id);
            if (product != null)
            {
                return product;

            }

            throw new ElementNotFoundException("Cart");

        }

        public Product AddProduct(Product product)
        {

            Product result = _repository.Add(product);

            if(result != null)
            {
                return result;
            }
            throw new InsertErrorException("Cart");

        }

        public Product UpdateProduct(CartItem cartItem)
        {
            Product product = _repository.GetByKey(productId);
            

            if (result != null)
            {
                return result;
            }
            throw new InsertErrorException("Cart");

        }

    }
}

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

        public Product GetProductByKey(int id)
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

        public Product Update(Product item, int quantity)
        {

            Predicate<Product> predicate = (C) => C.Id == item.Id;

            Product product = _repository.Find(predicate);

            product.QuantityInHand = product.QuantityInHand - quantity;


            return product;


        }

    }
}

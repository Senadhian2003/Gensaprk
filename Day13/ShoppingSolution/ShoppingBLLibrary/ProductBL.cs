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

        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = await _repository.GetAll();

            if (products.Count>0)
            {
                return products;
            }

            throw new EmptyListException("Product");

        }

        public async Task<Product> GetProductByKey(int id)
        {
            Product product = await _repository.GetByKey(id);
            if (product != null)
            {
                return product;

            }

            throw new ElementNotFoundException("Product");

        }

        public async Task<Product> AddProduct(Product product)
        {

            Product result = await _repository.Add(product);

            if(result != null)
            {
                return result;
            }
            throw new InsertErrorException("Product");

        }

        public async Task<Product> Update(Product item, int quantity)
        {

            //Predicate<Product> predicate = (C) => C.Id == item.Id;

            //Product product = _repository.Find(predicate);

            //product.QuantityInHand = product.QuantityInHand - quantity;

            item.QuantityInHand = item.QuantityInHand - quantity;


            Product result = await _repository.Update(item);

            if(result != null)
            {
                //Console.WriteLine(result);
                return result;

            }

            throw new ElementNotFoundException("Product");


        }

    }
}

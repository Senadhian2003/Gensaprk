using ShoppingBLLibrary.Exceptions;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    
    public class CustomerBL
    {
        readonly IRepository<int, Customer> _repository;

        public CustomerBL() {
            _repository = new CustomerRepository();
        }

        public Customer AddCustomer(Customer customer, CartBL cartBL)
        {
            Customer result = _repository.Add(customer);

            if(result==null)
            {
                throw new InsertErrorException("Customer");
            }

            Cart cart = new Cart(result);

            Cart cartResult =  cartBL.AddCart(cart);

            return result;

        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = _repository.GetAll().ToList();

            if (customers != null)
            {
                return customers;
            }

            throw new EmptyListException("Customer");
        }

        
    }
}

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

        public async Task<Customer> AddCustomer(Customer customer, CartBL cartBL)
        {
            Customer result = await _repository.Add(customer);

            if(result==null)
            {
                throw new InsertErrorException("Customer");
            }

            Cart cart = new Cart(result);

            Cart cartResult = await  cartBL.CreateCart(cart);

            return result;

        }

        public async Task<List<Customer>> GetAll()
        {
            List<Customer> customers = await _repository.GetAll();

            if (customers.Count>0)
            {
                return customers;
            }

            throw new EmptyListException("Customer");
        }

        
    }
}

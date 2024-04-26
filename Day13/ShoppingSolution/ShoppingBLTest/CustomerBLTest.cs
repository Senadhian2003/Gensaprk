using ShoppingBLLibrary;
using ShoppingBLLibrary.Exceptions;
using ShoppingModelLibrary;
using System.Xml.Linq;

namespace ShoppingBLTest
{
    public class Test
    {

        CustomerBL customerBL;
        CartBL cartBL;
        [SetUp] 
        public void Setup()
        {
            customerBL = new CustomerBL();
            cartBL = new CartBL();
        }

        [Test]
        public void AddCustomer()
        {
            Customer customer1 = new Customer() { Name = "Sena", Age = 18, Phone = "8678900238" };
           
           Customer result = customerBL.AddCustomer(customer1, cartBL);
           
            Assert.IsNotNull(result);

        }

        [Test]
        public void AddCustomerFail()
        {
            Customer customer1 = new Customer() { Name = "Sena", Age = 18, Phone = "8678900238" };
            Customer customer2 = new Customer() { Name = "Sena", Age = 18, Phone = "8678900238" };
            Customer result = customerBL.AddCustomer(customer1, cartBL);
            var expression = Assert.Throws<InsertErrorException>(() => customerBL.AddCustomer(customer2, cartBL));
            Assert.IsNotNull("The Customer was not added.",expression.Message);

        }

        [Test]
        public void GetAll()
        {
            Customer customer1 = new Customer() { Name = "Sena", Age = 18, Phone = "8678900238" };
            Customer customer2 = new Customer() { Name = "Spiderman", Age = 18, Phone = "8678900238" };
            customerBL.AddCustomer(customer1, cartBL);
            customerBL.AddCustomer(customer2, cartBL);

            List <Customer> customers = customerBL.GetAll();   

            Assert.AreEqual(2,customers.Count());
        }

        [Test]
        public void GetAllCustomersFail()
        {

            var expression = Assert.Throws<EmptyListException>(() => customerBL.GetAll());

            Assert.AreEqual("The Customer list is empty", expression.Message);

        }

    }
}

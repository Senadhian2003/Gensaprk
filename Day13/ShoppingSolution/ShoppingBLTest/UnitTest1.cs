using ShoppingBLLibrary;
using ShoppingBLLibrary.Exceptions;
using ShoppingModelLibrary;
using System.Xml.Linq;

namespace ShoppingBLTest
{
    public class Tests
    {
        ProductBL productBL;

        [SetUp]
        public void Setup()
        {
            productBL = new ProductBL();
        }

        [Test]
        public void AddProduct()
        {
            Product product1 = new Product() { Name = "Shoes", Price = 100, QuantityInHand = 10 };
      
            Product result = productBL.AddProduct(product1);
            
            Assert.IsNotNull(result);
        }


        [Test]
        public void AddProductFail()
        {
            Product product1 = new Product() { Name = "Shoes", Price = 100, QuantityInHand = 10 };
            Product result = productBL.AddProduct(product1);
            var expression = Assert.Throws<InsertErrorException>(() => productBL.AddProduct(product1));

            Assert.IsNotNull("The Product was not added.",expression.Message);

        }

        public void GetProductById()
        {
            Product product1 = new Product() { Name = "Shoes", Price = 100, QuantityInHand = 10 };
            productBL.AddProduct(product1);
            Product result = productBL.GetProductByKey(1);
            Assert.IsNotNull(result);

        }

        public void GetProductByIdFail()
        {
            Product product1 = new Product() { Name = "Shoes", Price = 100, QuantityInHand = 10 };
            productBL.AddProduct(product1);
            var expression = Assert.Throws<ElementNotFoundException>(()=> productBL.GetProductByKey(1));

            Assert.AreEqual("The Product could not be found", expression.Message);

        }

        [Test]
        public void GetAllProducts()
        {
            Product product1 = new Product() { Name = "Shoes", Price = 100, QuantityInHand = 10 };
            Product product2 = new Product() { Name = "Boxes", Price = 20, QuantityInHand = 5 };
            productBL.AddProduct(product1);
            productBL.AddProduct(product2);
            List<Product> products = productBL.GetProducts();

            Assert.AreEqual (2, products.Count);

        }

        [Test]
        public void GetAllProductsFail()
        {

            var expression = Assert.Throws<EmptyListException>(() => productBL.GetProducts());

            Assert.AreEqual("The Product list is empty", expression.Message);

        }

        [Test]
        public void UpdateProduct()
        {
            Product product1 = new Product() { Name = "Shoes", Price = 100, QuantityInHand = 10 };
            Product product2 = new Product() { Name = "Boxes", Price = 20, QuantityInHand = 5 };
            productBL.AddProduct(product1);
            productBL.AddProduct(product2);

            Product updatedProduct = new Product() {Id=1, Name = "Shoes", Price = 100, QuantityInHand = 5 };

            Product product = productBL.Update(product1, 5);

            Assert.AreEqual(product.QuantityInHand, 5);

        }

        [Test]
        public void UpdateProductFail()
        {
            Product product1 = new Product() { Name = "Shoes", Price = 100, QuantityInHand = 10 };
            Product product2 = new Product() { Name = "Boxes", Price = 20, QuantityInHand = 5 };
            productBL.AddProduct(product1);
            productBL.AddProduct(product2);

            Product notRelatedProduct = new Product() { Id = 3, Name = "Shoes", Price = 100, QuantityInHand = 5 };

           

           var expression =  Assert.Throws<ElementNotFoundException>(() => productBL.Update(notRelatedProduct, 5));

            Assert.AreEqual("The Product could not be found", expression.Message);

        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary.Exceptions
{
    public class OutOfStockException : Exception
    {
        string message;

        public OutOfStockException()
        {
            message = "Item out of stock";
        }

        public override string Message => message;

    }
}

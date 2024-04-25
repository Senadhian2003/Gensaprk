using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary.Exceptions
{
    public class ListFullException : Exception
    {
        string message;
        public ListFullException(string name) {
            message = $"The {name} List is Full new item cannot be added";
        }
        public override string Message => message;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary.Exceptions
{
    public class InsertErrorException :Exception
    {
        string message;

        public InsertErrorException(string name)
        {
           message = $"The {name} was not added.";
        }

        public override string Message => message;

    }
}

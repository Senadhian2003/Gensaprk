using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary.Exceptions
{
    public class EmptyListException : Exception
    {
        string message;

        public EmptyListException(string element)
        {
            message = $"The {element} list is empty";
        }

        public override string Message => message;

    }
}

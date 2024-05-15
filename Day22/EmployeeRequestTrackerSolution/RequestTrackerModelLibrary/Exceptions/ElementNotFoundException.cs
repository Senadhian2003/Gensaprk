using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary.Exceptions
{
    public class ElementNotFoundException : Exception
    {
        string message;

        public ElementNotFoundException(string element)
        {
            message = $"The {element} could not be found";
        }

        public override string Message => message;

    }
}

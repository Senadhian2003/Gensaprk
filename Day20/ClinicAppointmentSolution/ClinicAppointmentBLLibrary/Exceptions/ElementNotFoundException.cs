using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class ElementNotFoundException : Exception
    {
        string message;

        public ElementNotFoundException(string name)
        {
            message = $"The {name} could not be found";
        }

        public override string Message => message;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmptyListException : Exception
    {
        string message;
        public EmptyListException(string name)
        {
            message = $"The {name} list is empty";
        }
        public override string Message => message;
    }
}

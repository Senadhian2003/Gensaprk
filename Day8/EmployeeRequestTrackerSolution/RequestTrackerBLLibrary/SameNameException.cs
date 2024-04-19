using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class SameNameException : Exception
    {
        string message;

        public SameNameException()
        {
            message = "Old name is same as new name";
        }

        public override string Message => message;

    }
}

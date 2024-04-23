using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class DuplicateNameException : Exception
    {
        string msg;
        public DuplicateNameException(string name)
        {
            msg = $"{name} name already exists";
        }
        public override string Message => msg;

    }
}

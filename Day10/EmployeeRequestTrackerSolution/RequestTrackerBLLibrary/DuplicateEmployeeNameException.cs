using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class DuplicateEmployeeNameException : Exception
    {
        string msg;
        public DuplicateEmployeeNameException()
        {
            msg = "Employee name already exists";
        }
        public override string Message => msg;

    }
}

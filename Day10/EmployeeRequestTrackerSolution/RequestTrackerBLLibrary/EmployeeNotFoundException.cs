using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmployeeNotFoundException : Exception
    {
        string message;

        public EmployeeNotFoundException()
        {
            message = "The employee could not be found";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class DepartmentNotFoundException : Exception
    {
        string message;

        public DepartmentNotFoundException()
        {
            message = "The department could not be found";
        }
    }
}

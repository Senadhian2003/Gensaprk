using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmptyDepartmentListException : Exception
    {
        string message;
        public EmptyDepartmentListException() {
            message = "The department list is empty";
        }
        public override string Message => message;
    }
}

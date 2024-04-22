using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary.Exceptions
{
    public class EmptyEmployeeListException : Exception
    {
        string message;
        public EmptyEmployeeListException()
        {
            message = "The employee list is empty";
        }
        public override string Message => message;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary.Exceptions
{
    public class EmptyRefundListException : Exception
    {
        string message;
        public EmptyRefundListException()
        {
            message = "The Refund list is empty";
        }
        public override string Message => message;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary.Exceptions
{
    public class RefundNotFoundException : Exception
    {
        string message;
        public RefundNotFoundException()
        {
            message = "The Refund data is not present";
        }
        public override string Message => message;

    }
}

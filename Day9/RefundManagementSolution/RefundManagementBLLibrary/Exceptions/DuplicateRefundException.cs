using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary.Exceptions
{
    public class DuplicateRefundException : Exception
    {
        string msg;
        public DuplicateRefundException() {
            msg = "Refund already exists";
        }
        
        public override string Message => msg;

    }
}

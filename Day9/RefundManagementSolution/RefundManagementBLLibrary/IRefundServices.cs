using RefundManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary
{
    public interface IRefundServices
    {

        Refund GetRefundById(int id);
        List<Refund> GetAllRefund();
        int AddRefund(Refund refund);

        Refund UpdateRefund(Refund refund);


    }
}

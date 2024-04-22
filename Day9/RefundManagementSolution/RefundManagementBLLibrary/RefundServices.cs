using RefundManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary
{
    public interface RefundServices
    {

        List<Refund> GetRefundDetails(Employee employee);
        List<Refund> GetAllRefund();
        Refund AddRefund(Refund refund);

        Refund UpdateRefund(Refund refund);


    }
}

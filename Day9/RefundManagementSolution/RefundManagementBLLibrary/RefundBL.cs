using RefundManagementBLLibrary.Exceptions;
using RefundManagementDALLibrary;
using RefundManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary
{
    public class RefundBL : IRefundServices
    {
        readonly IRepository<int, Refund> _refundRepository;

        public RefundBL()
        {
            _refundRepository = new RefundRepository();
        }

        public int AddRefund(Refund refund)
        {
            var result = _refundRepository.Add(refund);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateRefundException();
        }

        public List<Refund> GetAllRefund()
        {
            List<Refund> refundList;

            refundList = _refundRepository.GetAll();

            if (refundList != null)
            {
                return refundList;
            }

            throw new EmptyRefundListException();
        }

        public Refund UpdateRefund(Refund refund)
        {
            

            refund = _refundRepository.Update(refund);

           

            if (refund != null)
            {
                return refund;

            }

            throw new RefundNotFoundException();
        }

        public Refund GetRefundById(int id)
        {
            Refund refund;

            refund = _refundRepository.Get(id);

            if (refund != null)
            {
                return refund;
            }


            throw new RefundNotFoundException();

        }


    }
}

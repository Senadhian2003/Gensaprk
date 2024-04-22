using RefundManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementDALLibrary
{
    public class RefundRepository : IRepository<int, Refund>
    {
        readonly Dictionary<int, Refund> _refunds;
        public RefundRepository()
        {
            _refunds = new Dictionary<int, Refund>();
        }
        int GenerateId()
        {
            if (_refunds.Count == 0)
                return 1;
            int id = _refunds.Keys.Max();
            return ++id;
        }
        public Refund Add(Refund item)
        {
            if (_refunds.ContainsValue(item))
            {
                return null;
            }
            int id = GenerateId();
            item.Id = id;
            _refunds.Add(id, item);
            return item;
        }

        public Refund Delete(int key)
        {
            if (_refunds.ContainsKey(key))
            {
                var department = _refunds[key];
                _refunds.Remove(key);
                return department;
            }
            return null;
        }

        public Refund Get(int key)
        {
            return _refunds.ContainsKey(key) ? _refunds[key] : null;
        }

        public List<Refund> GetAll()
        {
            if (_refunds.Count == 0)
                return null;
            return _refunds.Values.ToList();
        }

        public Refund Update(Refund item)
        {

            if (_refunds.ContainsKey(item.Id))
            {
                _refunds[item.Id] = item;
                return item;
            }
            return item;
        }



    }
}

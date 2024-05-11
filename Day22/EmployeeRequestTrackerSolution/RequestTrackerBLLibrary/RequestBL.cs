using RequestTrackerBLLibrary.Interface;
using RequestTrackerDALLibrary;
using RequestTrackerDALLibrary.Interface;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestBL : IRequestBL
    {
        private readonly IRepository<int,Request> _repository;
        public RequestBL() {
            _repository = new RequestRepository(new RequestTrackerContext());
        }

        public async Task<Request> CreateRequest(Request request)
        {
            await _repository.Add(request);
            return request;
        }

        public async Task<Request> GetRequest(int RequestId)
        {
           Request result = await _repository.Get(RequestId);
            return result;
        }
    }
}

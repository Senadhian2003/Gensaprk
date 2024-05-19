using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<int, Request> _requestRepository;
        private readonly IRepository<int,Employee> _employeeRepository;
        public RequestService(IRepository<int, Request> requestRepository, IRepository<int, Employee> employeeRepository)
        { _requestRepository = requestRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<int> RaiseRequest(int employeeId, string requestMessage)
        {
            Employee employee = await _employeeRepository.Get(employeeId);

            Request request = new Request() { RequestStatus = "Ticket Raised", RequestRaisedBy = employee.Id };
            request.RequestMessage = requestMessage;
            await _requestRepository.Add(request);
            return request.RequestNumber;


            throw new NotImplementedException();
        }

        public async Task<Request> CloseRequest(int employeeId, int requestId)
        {
            Employee employee = await _employeeRepository.Get(employeeId);

            Request request = await _requestRepository.Get(requestId);
            request.RequestClosedBy = employee.Id;
            request.RequestStatus = "Closed";
            request.ClosedDate = DateTime.Now;
            await _requestRepository.Update(request);

            return request;

            
        }

        public async Task<List<Request>> ViewAllRequest()
        {
            var requests = await _requestRepository.Get();

           var result = requests.Where(r => r.RequestStatus == "Ticket Raised").OrderBy(r=>r.RequestDate);

            if (result.Any())
            {
                return result.ToList();
            }

            throw new NotImplementedException();
        }

        public async Task<List<Request>> ViewMyRequest(int employeeId)
        {
            var requests = await _requestRepository.Get();

            var result = requests.Where(r => r.RequestRaisedBy == employeeId).OrderBy(r => r.RequestDate);

            if (result.Any())
            {
                return result.ToList();
            }

            throw new NotImplementedException();
        }
    }
}

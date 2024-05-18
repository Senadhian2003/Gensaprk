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
    }
}

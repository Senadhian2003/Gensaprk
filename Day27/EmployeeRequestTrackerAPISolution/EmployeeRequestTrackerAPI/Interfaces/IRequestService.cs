using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IRequestService
    {

        public Task<int> RaiseRequest(int employeeId, string request);
        public Task<List<Request>> ViewAllRequest();

        public Task<List<Request>> ViewMyRequest(int employeeId);

        public Task<Request> CloseRequest(int employeeId, int requestId);

       
    }
}

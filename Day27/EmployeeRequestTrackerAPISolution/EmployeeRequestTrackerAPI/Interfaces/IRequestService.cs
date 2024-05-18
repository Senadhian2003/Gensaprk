using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IRequestService
    {

        public Task<int> RaiseRequest(int employeeId, string request);

    }
}

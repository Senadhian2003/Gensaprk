using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IAdminService
    {
        public Task<Employee> GetEmployeeByPhone(string phoneNumber);
        public Task<Employee> UpdateEmployeePhone(int id, string phoneNumber);
        public Task<IEnumerable<Employee>> GetEmployees();

        public Task<User> ActivateUser(int id);
       

    }
}

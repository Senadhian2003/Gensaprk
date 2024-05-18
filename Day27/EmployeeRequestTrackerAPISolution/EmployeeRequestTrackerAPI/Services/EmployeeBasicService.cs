using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Exceptions;
namespace EmployeeRequestTrackerAPI.Services
{
    public class EmployeeBasicService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _employeeRepository;
        private readonly IRepository<int, User> _userRepository;
        public EmployeeBasicService(IRepository<int, Employee> employeeRepository, IRepository<int, User> userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }
        public async Task<Employee> GetEmployeeByPhone(string phoneNumber)
        {
            var employee = (await _employeeRepository.Get()).FirstOrDefault(e => e.Phone == phoneNumber);
            if (employee == null)
                throw new NoSuchEmployeeException();
            return employee;

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _employeeRepository.Get();
            if (employees.Count() == 0)
                throw new NoEmployeesFoundException();
            return employees;
        }

        public async Task<Employee> UpdateEmployeePhone(int id, string phoneNumber)
        {
            var employee = await _employeeRepository.Get(id);
            if (employee == null)
                throw new NoSuchEmployeeException();
            employee.Phone = phoneNumber;
            employee = await _employeeRepository.Update(employee);
            return employee;
        }


        public async Task<User> ActivateUser(int id)
        {

            var user = await _userRepository.Get(id);

            if(user == null)
            {
                throw new NoSuchEmployeeException();
            }

            user.Status = "Active";
            await _userRepository.Update(user);

            return user;


        }


    }
}

using RequestTrackerBLLibrary.Interface;
using RequestTrackerDALLibrary;
using RequestTrackerDALLibrary.Interface;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class EmployeeLoginBL : IEmployeeLoginBL
    {
        private IRepository<int,Employee> _repository;
        public EmployeeLoginBL() {
            _repository = new EmployeeRepository(new RequestTrackerContext());
        }


        public async Task<bool> Login(Employee employee)
        {
           Employee emp = await _repository.GetByKey(employee.Id);

            if(emp != null)
            {
                if(emp.Password==employee.Password)
                {
                    return true;
                }

            }

            return false;
        }

        public async Task<Employee> GetEmployee(Employee employee)
        {
            Employee emp = await _repository.GetByKey(employee.Id);
            return emp;
           
        }


        public async Task<Employee> Register(Employee employee)
        {
            var result = await _repository.Add(employee);
            return result;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
           return await _repository.GetAll();
        }

    }
}

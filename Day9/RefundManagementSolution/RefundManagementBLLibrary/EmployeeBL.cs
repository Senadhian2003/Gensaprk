using RefundManagementBLLibrary.Exceptions;
using RefundManagementDALLibrary;
using RefundManagementModelLibrary;

namespace RefundManagementBLLibrary
{
    public class EmployeeBL : IEmployeeServices
    {
        readonly IRepository<int, Employee> _employeeRepository;

        public EmployeeBL()
        {
            _employeeRepository = new EmployeeRepository();
        }


        public int AddEmployee(Employee employee)
        {
            var result = _employeeRepository.Add(employee);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateEmployeeNameException();
        }

        public Employee ChangeEmployeeName(string employeeOldName, string employeeNewName)
        {
            Employee employee;
            if (employeeOldName == employeeNewName)
            {
                Console.WriteLine("The employee old name and new name are same. There is no need to change");
                employee = GetEmployeeByName(employeeOldName);
                return employee;
            }
            else
            {
                employee = GetEmployeeByName(employeeOldName);
                employee.Name = employeeNewName;
                employee = _employeeRepository.Update(employee);

            }

            if (employee != null)
            {
                return employee;

            }

            throw new EmployeeNotFoundException();
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee;

            employee = _employeeRepository.Get(id);

            if (employee != null)
            {
                return employee;
            }


            throw new EmployeeNotFoundException();
        }

        public Employee GetEmployeeByName(string employeeName)
        {
            List<Employee> employeeList = _employeeRepository.GetAll();

            foreach (Employee employee in employeeList)
            {
                if (employee.Name == employeeName)
                {
                    return employee;
                }

            }

            throw new EmployeeNotFoundException();
        }



        public List<Employee> GetAllEmployees()
        {
            List<Employee> employeeList;

            employeeList = _employeeRepository.GetAll();

            if (employeeList != null)
            {
                return employeeList;
            }

            return null;
        }



    }
}

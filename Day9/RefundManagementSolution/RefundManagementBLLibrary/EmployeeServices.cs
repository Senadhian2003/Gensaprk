using RefundManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary
{
    public interface EmployeeServices
    {
        int AddEmployee(Employee employee);
        Employee ChangeEmployeeName(string employeeOldName, string employeeNewName);
        //Employee DeleteEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByName(string name);

        List<Employee> GetAllEmployees();

       

    }
}

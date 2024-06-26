﻿using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using RequestTrakerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
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

            if (employeeOldName == employeeNewName)
            {
                throw new DuplicateEmployeeNameException();
            }

            Employee employee = GetEmployeeByName(employeeOldName);

            employee.Name = employeeNewName ;

            employee = _employeeRepository.Update(employee);

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

      

        public List<Employee> GetEmployeeList()
        {
            List<Employee> employeeList;

            employeeList = _employeeRepository.GetAll();

            if (employeeList != null)
            {
                return employeeList;
            }

            throw new EmptyEmployeeListException();
        }


    }
}

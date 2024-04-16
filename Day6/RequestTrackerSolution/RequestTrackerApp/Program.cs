using RequestTrackerApp;
using RequestTrackerModelLibrary;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RequestTrackerApplication
{
    internal class Program
    {
        Employee[] employees;
        public Program()
        {
            employees = new Employee[3];
        }
        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Update Employee name");
            Console.WriteLine("5. Delete Employee Detail");
            Console.WriteLine("0. Exit");
        }
        static bool getName(string input, out string name)
        {
            name = "";
            string pattern = @"^[a-zA-Z\s]+$";

            bool patternMatch = Regex.IsMatch(input, pattern);

            if (patternMatch)
            {
                name = input;
                return true;
            }
            return false;


        }
        void UpdateNameOfEmployee(Employee employee)
        {
            Console.WriteLine("Enter New name of employee");

            string name;

            while (!getName(Console.ReadLine(), out name))
            {
                Console.WriteLine("This is not a valid name. Please enter valid name");
            }

            employee.Name = name;
            return;

        }

        void UpdateEmployee()
        {
            Employee employee;
            Console.WriteLine("Enter the id of the employee you want to update");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid id. Please enter a vaild id");
            }
            employee = SearchEmployeeById(id);

            if (employee == null)
            {
                Console.WriteLine("No employee found with the specified id");
                return;
            }

            UpdateNameOfEmployee(employee);


        }

        void DeleteEmployeeById(int id)
        {
            for (int i = 0; i < employees.Length; i++)
            {

                if (employees[i] != null && employees[i].Id == id)
                {
                    employees[i] = null;
                    return;
                }
            }

            Console.WriteLine("No employee with specified id is present");

        }

        void DeleteEmployee()
        {
            Console.WriteLine("Enter id of the employee you want to delete");

            int employeeId;

            while (!int.TryParse(Console.ReadLine(), out employeeId))
            {
                Console.WriteLine("Invalid id. Please enter a valid id");
            }
            DeleteEmployeeById(employeeId);


        }

        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        SearchAndPrintEmployee();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        void AddEmployee()
        {
            //if (employees[employees.Length - 1] != null)
            //{
            //    Console.WriteLine("Sorry we have reached the maximum number of employees");
            //    return;
            //}

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                    return;
                }
            }
            Console.WriteLine("Sorry we have reached the maximum number of employees");

        }
        void PrintAllEmployees()
        {
            //if (employees[0] == null)
            //{
            //    Console.WriteLine("No Employees available");
            //    return;
            //}

            int flag = 0;

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                {
                    PrintEmployee(employees[i]);
                    flag = 1;
                }


            }

            if (flag == 0)
            {
                Console.WriteLine("No Employees available");
            }

        }
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter the type of employee");
            string type = Console.ReadLine();
            if (type == "Permanent")
                employee = new PermanentEmployee();
            else if (type == "Contract")
                employee = new ContractEmployee();
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }
        int GetIdFromConsole()
        {
            int id = 0;
            Console.WriteLine("Please enter the employee Id");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }
        void SearchAndPrintEmployee()
        {
            Console.WriteLine("Print One employee");
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            PrintEmployee(employee);
        }
        Employee SearchEmployeeById(int id)
        {
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {

                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }



        static void Main(string[] args)
        {
            Program program = new Program();
            //program.EmployeeInteraction();

            Employee employee = new ContractEmployee(101, "Spiderman", DateTime.Now, 90);

            //Console.WriteLine(employee);
            Company company = new Company();
            company.EmployeeClientVisit(employee);


        }
    }
}

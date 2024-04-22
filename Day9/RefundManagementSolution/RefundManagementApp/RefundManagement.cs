using RefundManagementBLLibrary;
using RefundManagementBLLibrary.Exceptions;
using RefundManagementModelLibrary;

namespace RefundManagementApp
{
    internal class RefundManagement
    {

        EmployeeBL employeeBL;
        RefundBL refundBL;
        Employee employee;
        public RefundManagement()
        {

            employeeBL = new EmployeeBL();
            refundBL = new RefundBL();

        }


        void AddEmployee()
        {
            try
            {


                Employee employee = new Employee();
                employee.BuildEmployeeFromConsole();

                employeeBL.AddEmployee(employee);


            }
            catch (DuplicateEmployeeNameException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        void UpdateEmployee()
        {
            try
            {
                Console.WriteLine("Enter Employee Name you want to change");
                string oldEmployeeName = Console.ReadLine();
                Console.WriteLine("Enter new Employee Name");
                string newEmployeeName = Console.ReadLine();

                employeeBL.ChangeEmployeeName(oldEmployeeName, newEmployeeName);
            }
            catch (DuplicateEmployeeNameException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        void getEmployeeByName()
        {
            try
            {
                Console.WriteLine("Enter Employee Name");
                string employeeName = Console.ReadLine();
                Employee employee = employeeBL.GetEmployeeByName(employeeName);
                Console.WriteLine(employee.ToString());
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        void getEmployeeById()
        {
            try
            {
                Console.WriteLine("Enter Employee Id ");
                int employeeId = Convert.ToInt32(Console.ReadLine());
                Employee employee = employeeBL.GetEmployeeById(employeeId);
                Console.WriteLine(employee.ToString());
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }



        void GetAllEmployees()
        {
            try
            {
                foreach (Employee employee in employeeBL.GetAllEmployees())
                {
                    Console.WriteLine(employee.ToString());
                }
            }
            catch (EmptyEmployeeListException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }

        void EmployeeInteraction()
        {
            int choice = 0;

            List<Employee> employees = employeeBL.GetAllEmployees();

            if (employees == null)
            {
                Console.WriteLine("There are no employees, Enter your Details");

                employee = new Employee();
                employee.BuildEmployeeFromConsole();
                employeeBL.AddEmployee(employee);
                Console.WriteLine("New Hr added successfully");
            }



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

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

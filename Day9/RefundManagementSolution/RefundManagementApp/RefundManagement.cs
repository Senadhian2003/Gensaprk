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


        void PrintMenuForHR()
        {
            Console.WriteLine("HR Functionalities");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Update Employee name");
            Console.WriteLine("5. View All Refund");
            Console.WriteLine("5. Update refund status");
            Console.WriteLine("0. Exit");
        }

        void PrintMenuForEmployee()
        {
            Console.WriteLine("Employee Functionalities");
            Console.WriteLine("1. Apply For Refund");
            Console.WriteLine("2. View Refund status");
            Console.WriteLine("0. Exit");
        }


        void AddEmployee()
        {
            try
            {
                Console.WriteLine("Enter the type of employee");
                string employeeType = Console.ReadLine();
                Employee employee;
                if(employeeType == "Employee")
                {
                    employee = new Employee();
                }
                else
                {
                    employee = new HREmployee();
                }

               
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



        void PrintAllEmployees()
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


        private void UpdateRefundStatus()
        {
            try
            {
                Console.WriteLine("Enter Refund Id you want to verify");
                int refundId = Convert.ToInt32(Console.ReadLine());

                Refund refund = refundBL.GetRefundById(refundId);
                Console.WriteLine("Enter the status of the refund");
                string status = Console.ReadLine();
                string reason;
                if (status == "Granted")
                {
                    refund.Status = "Granted";
                    refund.Reason = "All proofs verified";
                }
                else
                {
                    refund.Status = "Rejected";
                    Console.WriteLine("Enter reason for rejection");

                    refund.Reason = Console.ReadLine();
                }

                refundBL.UpdateRefund(refund);

            }
            catch (DuplicateEmployeeNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ViewAllRefund()
        {
            try
            {
                foreach (Refund refund in refundBL.GetAllRefund())
                {
                    Console.WriteLine(refund.ToString());
                }
            }
            catch (EmptyRefundListException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }


        }

        private void SearchAndPrintEmployeeById()
        {
            try
            {
                Console.WriteLine("Enter Employee Id ");
                int departmentId = Convert.ToInt32(Console.ReadLine());
                Employee employee = employeeBL.GetEmployeeById(departmentId);
                Console.WriteLine(employee.ToString());
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        void ApplyForRefund()
        {
            try
            {
                Refund refund = new Refund(employee);

                refund.BuildRefundDataFromConsole();

                refundBL.AddRefund(refund);
                Console.WriteLine("Refund Request Successful");
            }
            catch (DuplicateRefundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        void VerifyStatusOfRefund()
        {
            try
            {
                foreach (Refund refund in refundBL.GetAllRefund())
                {
                   
                    if(refund.EmployeeId == employee.Id) { 
                    
                    Console.WriteLine(refund.ToString());
                    }

                }
            }
            catch (EmptyRefundListException ex)
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

                employee = new HREmployee();
                employee.BuildEmployeeFromConsole();
                employeeBL.AddEmployee(employee);
                Console.WriteLine("New Hr added successfully");
            }
            else
            {
                Console.WriteLine("Enter your Id");
                int id = Convert.ToInt32(Console.ReadLine());
                employee = employeeBL.GetEmployeeById(id);


            }

            if (employee.Type == "HR")
            {


                do
                {
                    PrintMenuForHR();
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
                            SearchAndPrintEmployeeById();
                            break;
                        case 4:
                            UpdateEmployee();
                            break;
                        case 5:
                            ViewAllRefund();
                            break;
                        case 6:
                            UpdateRefundStatus();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again");
                            break;
                    }
                } while (choice != 0);
            }
            else
            {

                do
                {
                    PrintMenuForEmployee();
                    Console.WriteLine("Please select an option");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("Bye.....");
                            break;
                        case 1:
                            ApplyForRefund();
                            break;
                        case 2:
                            VerifyStatusOfRefund();
                            break;
                        
                        default:
                            Console.WriteLine("Invalid choice. Try again");
                            break;
                    }
                } while (choice != 0);


            }


            EmployeeInteraction();


        }


        static void Main(string[] args)
        {
           RefundManagement refundManagement = new RefundManagement();
            //Employee employee = new Employee();
            //employee.BuildEmployeeFromConsole();
            /*refundManagement.ApplyForRefund(employee)*/;
            refundManagement.EmployeeInteraction();

        }

    }

       
       
    }



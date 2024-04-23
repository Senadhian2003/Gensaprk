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

    

        /// <summary>
        /// Adds a new Employee to the repository
        /// </summary>
        void AddEmployee()
        {
            try
            {
                Console.WriteLine("Enter the type of employee");
                string employeeType = Console.ReadLine();
                Employee employee;
                if(employeeType != "HR")
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

        /// <summary>
        /// Updates the Name of the employee
        /// </summary>
        void UpdateEmployee()
        {
            try
            {
                Console.WriteLine("Enter Employee Name you want to change");
                string oldEmployeeName = Console.ReadLine();
                Console.WriteLine("Enter new Employee Name");
                string newEmployeeName = Console.ReadLine();

                employeeBL.ChangeEmployeeName(oldEmployeeName, newEmployeeName);

                Console.WriteLine("Employee updated successfully");

            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        /// <summary>
        /// Prints the employee details of an employee using the given name
        /// </summary>
        void getEmployeeByName()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter Employee Name");
                string employeeName = Console.ReadLine();
                Employee employee = employeeBL.GetEmployeeByName(employeeName);
                Console.WriteLine(employee.ToString());
                Console.WriteLine();
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

       

        /// <summary>
        /// Prints all the employee details for the HR
        /// </summary>

        void PrintAllEmployees()
        {
            try
            {
                foreach (Employee employee in employeeBL.GetAllEmployees())
                {
                    Console.WriteLine(employee.ToString());
                }
                Console.WriteLine();
            }
            catch (EmptyEmployeeListException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }

        /// <summary>
        /// Update the Refund details submitted by employeee
        /// </summary>
        private void UpdateRefundStatus()
        {
            try
            {
                Console.WriteLine("Enter Refund Id you want to verify");
                int refundId = Convert.ToInt32(Console.ReadLine());

                Refund refund = refundBL.GetRefundById(refundId);
                Console.WriteLine("Enter the status of the refund");
                string status = Console.ReadLine();
                
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
                Console.WriteLine();

            }
            catch (RefundNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Prints all the Refund details
        /// </summary>
        private void ViewAllRefund()
        {
            try
            {
                foreach (Refund refund in refundBL.GetAllRefund())
                {
                    Console.WriteLine(refund.ToString());
                }
                Console.WriteLine();
            }
            catch (EmptyRefundListException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }


        }

        /// <summary>
        /// Prints a particular employee using given id
        /// </summary>
        private void SearchAndPrintEmployeeById()
        {
            try
            {
                Console.WriteLine("Enter Employee Id ");
                int departmentId = Convert.ToInt32(Console.ReadLine());
                Employee employee = employeeBL.GetEmployeeById(departmentId);
                Console.WriteLine(employee.ToString());
                Console.WriteLine();
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        /// <summary>
        /// Allow employees to apply for a refund
        /// </summary>
        void ApplyForRefund()
        {
            try
            {
                Refund refund = new Refund(employee);

                refund.BuildRefundDataFromConsole();

                refundBL.AddRefund(refund);
                Console.WriteLine("Refund Request Successful");
                Console.WriteLine();
            }
            catch (DuplicateRefundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Verify the refund status of the submission
        /// </summary>
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
                Console.WriteLine();
            }
            catch (EmptyRefundListException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }




        }

        /// <summary>
        /// View the refunds that have not yet been verified
        /// </summary>
        private void ViewUnverifiedRefund()
        {
            try
            {
                foreach (Refund refund in refundBL.GetAllRefund())
                {
                    if (refund.Status == "Not verified")
                    {
                        Console.WriteLine(refund.ToString());
                    }
                }
                Console.WriteLine();
            }
            catch (EmptyRefundListException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }


        /// <summary>
        /// Provide employee interactions
        /// </summary>
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
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Hey new user enter your id");
                int id = Convert.ToInt32(Console.ReadLine());
                employee = employeeBL.GetEmployeeById(id);
                Console.WriteLine();


            }

            if (employee.Type == "HR")
            {


                do
                {
                    employee.PrintMenuForEmployee();
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
                            ViewUnverifiedRefund();
                            break;
                        case 7:
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
                    employee.PrintMenuForEmployee();
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



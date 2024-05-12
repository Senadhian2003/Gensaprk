using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    public class UserDashboard
    {
        EmployeeBL employeeBL;
        Employee employee;
        public UserDashboard(Employee emp) {
            employeeBL = new EmployeeBL();
            employee = emp;
        }

        async void RaiseRequest()
        {
            int requestId = await employeeBL.RaiseRequest(employee);
            Console.WriteLine("Your request has been raised with request number : " + requestId);

        }

        async void ViewRequestStatus()
        {
            empl

        }


        public void Interactions()
        {
            int choice;
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
                        RaiseRequest();
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


    }
}

using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    public class EmployeeDashboard
    {
        public EmployeeBL employeeBL;
        public Employee employee;
        public EmployeeDashboard(Employee emp) {
            employeeBL = new EmployeeBL();
            employee = emp;
        }
        public EmployeeDashboard(Employee emp, AdminBL bl)
        {
            employeeBL = bl;
            employee = emp;
        }

        public async Task RaiseRequest()
        {
            int requestId = await employeeBL.RaiseRequest(employee);
            Console.WriteLine("Your request has been raised with request number : " + requestId);

        }

        public async Task ViewRequestStatus()
        {
            List<Request> requests = employeeBL.ViewRequestStatus(employee);

            Console.WriteLine("Requests Raised");
            foreach(Request request in requests)
            {
                Console.WriteLine(request);
            }
            Console.WriteLine();

        }

        public async Task ViewSolutions()
        {
            List<RequestSolution> solutions = await employeeBL.ViewSolution(employee);

            Console.WriteLine("Solutions for the Request......");
            foreach (RequestSolution solution in solutions)
            {
                Console.WriteLine(solution);
            }
            Console.WriteLine();

        }

        public async Task GiveFeedback()
        {
            SolutionFeedback feedback = await employeeBL.GiveFeedback(employee);

            Console.WriteLine("Feedback added successfully");

        }

        public async Task RespondToSolution()
        {
            bool responseFlag =  await employeeBL.RespondToSolution(employee);
            if(responseFlag)
            {
                Console.WriteLine("Response Added Successfully");
            }
            else
            {
                Console.WriteLine("Error in adding response");
            }

        }

        public void PrintMenuForEmployee()
        {
            Console.WriteLine();
            Console.WriteLine("Employee Functionalities");
            Console.WriteLine("1. Raise Request");
            Console.WriteLine("2. View Request status");
            Console.WriteLine("3. View Solutions");
            Console.WriteLine("4. Give Feedback");
            Console.WriteLine("5. Respond to solution");
            Console.WriteLine("0. Logout");
            
        }

        public async Task Interactions()
        {
            int choice;
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
                        RaiseRequest();
                        break;
                    case 2:
                        ViewRequestStatus();
                        break;
                    case 3:
                        ViewSolutions();
                        break;
                    case 4:
                        GiveFeedback();
                        break;
                    case 5:
                        RespondToSolution();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);



        }


    }
}

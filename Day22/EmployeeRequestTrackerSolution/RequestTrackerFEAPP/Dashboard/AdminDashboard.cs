using RequestTrackerBLLibrary.BussinessLogics;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP.Dashboard
{
    public class AdminDashboard : EmployeeDashboard
    {
        AdminBL adminBL;
        public AdminDashboard(Employee emp) : base(emp)
        {

            adminBL = new AdminBL();

        }

        public void PrintMenuForAdmin()
        {
            Console.WriteLine();
            Console.WriteLine("Employee Functionalities");
            Console.WriteLine("1. Raise Request");
            Console.WriteLine("2. View Request status");
            Console.WriteLine("3. View Solutions");
            Console.WriteLine("4. Give Feedback");
            Console.WriteLine("5. Respond to solution");
            Console.WriteLine("6. Provide solution");
            Console.WriteLine("7. Close Ticket");
            Console.WriteLine("8. View Feedbacks");
            Console.WriteLine("0. Logout");

        }

        public async Task ProvideSolution()
        {
            RequestSolution requestSolution = await adminBL.ProvideSolution(employee);

            if (requestSolution != null)
            {
                Console.WriteLine("Your solution has been added successfully");
            }

        }


        public async Task CloseRequest()
        {
            Request request = await adminBL.CloseRequest(employee);

            Console.WriteLine("Reqeust Closed...");
            Console.WriteLine(request);

        }

        public async Task ViewFeedback()
        {
            List<SolutionFeedback> feedbacks = await adminBL.GetSolutionFeedback(employee);

            foreach (SolutionFeedback feedback in feedbacks)
            {
                Console.WriteLine("Feedback Id : " + feedback.Remarks
                    + "\nFeedback :" + feedback.Remarks
                    + "\nRating : " + feedback.Rating
                    + "\nRaised By : " + feedback.FeedbackByEmployee.Name
                    );
            }

        }


        public async Task Interactions()
        {
            int choice;
            do
            {
                PrintMenuForAdmin();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        await RaiseRequest();
                        break;
                    case 2:
                        await ViewRequestStatus();
                        break;
                    case 3:
                        await ViewSolutions();
                        break;
                    case 4:
                        await GiveFeedback();
                        break;
                    case 5:
                        await RespondToSolution();
                        break;
                    case 6:
                        await ProvideSolution();
                        break;
                    case 7:
                        await CloseRequest();
                        break;
                    case 8:
                        await ViewFeedback();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);



        }



    }
}

using RequestTrackerBLLibrary.Interface;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class AdminBL : EmployeeBL, IAdminServices
    {
       
      
        public async Task<Request> CloseRequest(Employee employee)
        {
            List<Request> list = await GetAllRequests();

            foreach (Request request in list)
            {
                Console.WriteLine(request);

            }

            Console.WriteLine("Enter the request number to mark as closed");

            int requestNumber = Convert.ToInt32(Console.ReadLine());

            Request request1 = await _requestRepository.GetByKey(requestNumber);

            if(request1 != null)
            {
                request1.RequestStatus = "Ticket Closed";
                _requestRepository.Update(request1);
                return request1;
            }


            throw new NotImplementedException();
        }

        public async Task<List<Request>> GetAllRequests()
        {
            return await _requestRepository.GetAll();

        }

        public async Task<RequestSolution> ProvideSolution(Employee employee)
        {
            List<Request> list = await GetAllRequests();

            foreach (Request request in list)
            {
                Console.WriteLine(request);

            }
            Console.WriteLine();

            Console.WriteLine("Enter the request number to provide a solution");

            int requestNumber = Convert.ToInt32(Console.ReadLine());

            Request request1 = await _requestRepository.GetByKey(requestNumber);
            if(request1 != null) {
                {
                    RequestSolution requestSolution = new RequestSolution()
                    {
                        RequestId = request1.RequestNumber,
                        RequestRaised = request1,
                        SolvedBy = employee.Id,
                        SolvedByEmployee = employee,
                        SolvedDate = DateTime.Now,
                        IsSolved = false
                    };
                    requestSolution.GetSolutionDescription();

                    await _requestSolutionRepository.Add(requestSolution);

                    return requestSolution;
                }

            }
           

            throw new NotImplementedException();
        }

        public async Task<List<SolutionFeedback>> GetSolutionFeedback(Employee employee)
        {
            List<RequestSolution> solutions = await _requestSolutionRepository.GetAll();

            List<SolutionFeedback> feedbacks = new List<SolutionFeedback>();

            foreach (RequestSolution solution in solutions)
            {
                
                if(solution.SolvedBy == employee.Id)
                {
                    Console.WriteLine(solution);

                    foreach(SolutionFeedback feedback in solution.Feedbacks)
                    {
                        Console.WriteLine(feedback);
                    }


                }


            }

            throw new NotImplementedException();
        }


    }
}

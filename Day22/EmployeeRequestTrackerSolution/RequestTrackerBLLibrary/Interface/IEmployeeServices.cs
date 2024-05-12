using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.Interface
{
    public interface IEmployeeServices
    {

        Task<int> RaiseRequest(Employee employee);

        List<Request> ViewRequestStatus(Employee employee);

        Task<List<RequestSolution>> ViewSolution(Employee employee);
        Task<SolutionFeedback> GiveFeedback(Employee employee);

        Task<bool> RespondToSolution(Employee employee);


    }
}

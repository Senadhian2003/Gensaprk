using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    public class SolutionFeedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public float Rating { get; set; }
        public string? Remarks { get; set; }
        public int SolutionId { get; set; }
        public RequestSolution Solution { get; set; }
        public int FeedbackBy { get; set; }
        public Employee FeedbackByEmployee { get; set; }
        public DateTime FeedbackDate { get; set; }

        public SolutionFeedback(Employee employee, RequestSolution solution)
        {
            FeedbackDate = DateTime.Now;
            FeedbackByEmployee = employee;
            FeedbackBy = employee.Id;
            Solution = solution;
            SolutionId = solution.SolutionId;
        }

        public void GetFeedBack()
        {
            Console.WriteLine("Enter the Feedback for solution");

            Remarks = Console.ReadLine();

            Console.WriteLine("How well would you rate the solution out of 10");

            Rating = (float)Convert.ToDecimal( Console.ReadLine());

        }

    }
}

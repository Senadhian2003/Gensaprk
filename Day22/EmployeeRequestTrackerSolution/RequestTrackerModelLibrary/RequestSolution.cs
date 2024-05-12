using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RequestTrackerModelLibrary
{
    public class RequestSolution
    {
        [Key]
        public int SolutionId { get; set; }

        public int RequestId { get; set; }

        public Request RequestRaised { get; set; }

        public string SolutionDescription { get; set; }

        public int SolvedBy { get; set; }

        public Employee SolvedByEmployee { get; set; }

        public DateTime SolvedDate { get; set; }
        public bool IsSolved { get; set; } = false;
        public string? RequestRaiserComment { get; set; }

        public ICollection<SolutionFeedback> Feedbacks { get; set; }


        //public RequestSolution(Employee employee, Request request)
        //{
        //    RequestId = request.RequestNumber;
        //    RequestRaised = request;
        //    SolvedBy = employee.Id;
        //    SolvedByEmployee = employee;
        //    SolvedDate = DateTime.Now;

        //}

        public void GetSolutionDescription()
        {
            Console.WriteLine("Enter Solution Description");

            SolutionDescription = Console.ReadLine();

        }


        public override string ToString()
        {
            return "\n"
                + "--------------------------------"
                + "\nSolution Id : " + SolutionId
                + "\nSolution Description " + SolutionDescription
                + "\nSolved By : " + SolvedByEmployee.Name
                + "\nSolved Date : " + SolvedDate
                + "\nComment : " + RequestRaiserComment
                + "\n"
                + "--------------------------------";



        }


    }
}

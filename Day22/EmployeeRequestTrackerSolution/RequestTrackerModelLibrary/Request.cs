using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RequestTrackerModelLibrary
{
    public class Request
    {

        [Key]
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; }


        public int? RequestRaisedBy { get; set; }

        public Employee RaisedByEmployee { get; set; }

        public int? RequestClosedBy { get; set; }


        public Employee RequestClosedByEmployee { get; set; }

        public ICollection<RequestSolution> RequestSolutions { get; set; }


        //public Request(Employee employee)
        //{

        //    RequestStatus = "Ticket Raised";
        //    RaisedByEmployee = employee;
        //    RequestRaisedBy = employee.Id;
        //}

        public void BuildRequestFromConsole()
        {
            Console.WriteLine("Enter the issue");
            RequestMessage = Console.ReadLine();

        }

        public override string ToString()
        {
            return "\n"
                + "--------------------------------"
                + "\nRequest Id : " + RequestNumber
                + "\nRequest Message : " + RequestMessage
                + "\nStatus : " + RequestStatus
                + "\nTicket raised date : " + RequestDate;
                
               



        }


    }
}

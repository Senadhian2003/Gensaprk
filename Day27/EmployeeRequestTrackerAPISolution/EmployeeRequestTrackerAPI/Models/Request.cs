using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRequestTrackerAPI.Models
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
        [ForeignKey("RequestRaisedBy")]
        public Employee RaisedByEmployee { get; set; }

        public int? RequestClosedBy { get; set; }

        [ForeignKey("RequestClosedBy")]
        public Employee RequestClosedByEmployee { get; set; }


        

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

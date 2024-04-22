using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RefundManagementModelLibrary
{
    public class Refund
    {

        public int EmployeeId { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public float Amount { get; set; }

        public string Status { get; set; }

        public string Reason { get; set; }
        public Refund() {
        
            Id= 0;
            Type = String.Empty;
            Description = String.Empty;
            DateTime = DateTime.MinValue;
            Amount = 0;
            Status = "Not verified";
            Reason = "None";

        }

        public Refund(Employee employee)
        {
            EmployeeId = employee.Id;
            Status = "Not verified";
            Reason = "None";
        }

        public override string ToString()
        {

            return "\nRefund Id\t: " + Id
                + "\nDescription of Expense\t" + Description
                + "\nDate of expense\t: " + DateTime
                + "\nType of Expense\t: " + Type
                +"\nAmount\t: " + Amount
                + "\nStatus of refund\t: " + Status
                + "\nReason\t: " + Reason;

        }

        public virtual void BuildRefundDataFromConsole()
        {
            Console.WriteLine("Please enter the Type of Refund");
            Type = Console.ReadLine() ?? String.Empty;

            Console.WriteLine("Please enter the Description of Refund");
            Description = Console.ReadLine() ?? String.Empty;


            Console.WriteLine("Please enter the Date of Expense");
            DateTime = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Please enter the Expense");
            Amount = Convert.ToInt32(Console.ReadLine());



        }

        public override bool Equals(object? obj)
        {
            Refund r1, r2;
            r1 = this;
            r2 = obj as Refund;
            return r1.Id.Equals(r2.Id);
        }




    }
}

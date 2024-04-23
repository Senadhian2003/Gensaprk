using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementModelLibrary
{
    public class HREmployee : Employee
    {
        public HREmployee() {
            Type = "HR";
        }

        public override void PrintMenuForEmployee()
        {
            Console.WriteLine();
            Console.WriteLine("HR Functionalities");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Update Employee name");
            Console.WriteLine("5. View All Refund");
            Console.WriteLine("6. View Unverified Refund");
            Console.WriteLine("7. Update refund status");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
        }

      


    }
}

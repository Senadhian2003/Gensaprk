using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyModelLibrary
{
    public class AccentureEmployee : Employee
    {

        public AccentureEmployee(int id, string name, string dept, double basicSalary,int serviceCompleted) : base (id, name, dept, basicSalary, serviceCompleted) { 
        
        }
        public double Gratuity { get; set; }

        /// <summary>
        /// Calculate Employee Pension fund
        /// </summary>
        /// <returns>Employee Pension Fund</returns>
        public override double EmployeePf()
        {
            double pf = (BasicSalary * 12) / 100;

            BasicSalary = BasicSalary - ((BasicSalary*3.67)/100);

            return pf;
        }

        /// <summary>
        /// Returns Gratuity Amount of Employee
        /// </summary>
        /// <returns></returns>
        public override double GratuityAmount()
        {
           if(ServiceCompleted>5 && ServiceCompleted < 10)
            {
                Gratuity = BasicSalary;
            }
           else if (ServiceCompleted > 10 && ServiceCompleted < 20)
            {
                Gratuity = 2 * BasicSalary;
            }
            else if (ServiceCompleted > 20)
            {
                Gratuity = 3 * BasicSalary;
            }
            else
            {
                Gratuity = 0;
            }

           return Gratuity;


        }
        /// <summary>
        /// Returns Leave Details of Employee
        /// </summary>
        /// <returns></returns>
        public override string LevDetails()
        {
            return "1 day of Casual Leave per month\r\n12 days of Sick Leave per year\r\n10 days of Privilege Leave per year\r\n";
        }

        /// <summary>
        /// Prints Details of the Employee
        /// </summary>
        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine("Gratuitu\t:" + Gratuity);
        }


    }
}

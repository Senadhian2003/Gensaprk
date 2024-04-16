using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyModelLibrary
{
    internal class TcsEmployee : Employee
    {
        public TcsEmployee(int id, string name, string dept, double basicSalary, int serviceCompleted) : base(id, name, dept, basicSalary, serviceCompleted)
        {

        }
       
        /// <summary>
        /// Calculate Employee Pension fund
        /// </summary>
        /// <returns>Employee Pension Fund</returns>
        public override double EmployeePf()
        {
            double pf = (BasicSalary * 12) / 100;
            double empPf = (BasicSalary * 12) / 100;
            BasicSalary = BasicSalary - ((BasicSalary * 12) / 100);

            return pf + empPf;
        }

        /// <summary>
        /// Returns Gratuity Amount of Employee
        /// </summary>
        /// <returns></returns>
        public override double GratuityAmount()
        {
            return -1;

        }

        /// <summary>
        /// Returns Leave Details of Employee
        /// </summary>
        /// <returns></returns>

        public override string LevDetails()
        {
            return "2 day of Casual Leave per month\r\n5 days of Sick Leave per year\r\n5 days of Previlage Leave per year\r\n";
        }

    }
}

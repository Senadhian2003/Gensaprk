using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyModelLibrary
{
    public class Employee : GovRules
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Dept { get; set; }

        public double BasicSalary { get; set; }
       
        public int ServiceCompleted { get; set; }
        public double Pf { get; set; }

        public Employee(int id, string name, string dept, double basicSalary, int serviceCompleted)
        {
            Id = id;
            Name = name;
            Dept = dept;
            BasicSalary = basicSalary;
            ServiceCompleted = serviceCompleted;    
        }

        /// <summary>
        /// Prints Employee Details
        /// </summary>
       public virtual void PrintDetails()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Id\t:" + Id);
            Console.WriteLine("Name\t:" + Name);
            Console.WriteLine("Dept\t:" + Dept);
            Console.WriteLine("Basic Salary\t:" + BasicSalary);
            Console.WriteLine("Leave Details \t:" + LevDetails());

        }

        public virtual double EmployeePf()
        {
            return 0;
        }
        

        public virtual string LevDetails()
        {
            return " ";
        }

        public virtual double GratuityAmount()
        {
            return 0;
        }
    }
}

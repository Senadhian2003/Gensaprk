using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientation.Models
{
    class Employee
    {
        //private int id;
        //private string name;

        //public int getId()
        //{
        //    return id;
        //}

        //public string getName()
        //{
        //    return name;
        //}

        //public void setId(int id)
        //{
        //    this.id = id;
        //}

        //public void setName(string name)
        //{
        //        this.name = name;
        //}


        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public void manipulateName()
        {
            Name = "Sena";
        }


        private double salary;

        public Employee(int id)
        {
            Id = id;

        }

        public Employee(int id, string name, string email) : this(id)
        {
            Name = name;
            Email = email;
        }

        public double Salary
        {
            get
            {
                return salary - salary * 10 / 100;
            }

            set
            {
                salary = value;
            }


        }

        /// <summary>
        /// Print Hours worked
        /// </summary>
        /// <param name="hours">No of hours</param>
        /// <returns>String message of hours worked</returns>
        public string Work(int hours)
        {
            return $"Doing work for {hours} hours from morning";
        }


        public void printInfo()
        {
            Console.WriteLine("Id\t:\t" + Id);
            Console.WriteLine("Name\t:\t" + Name);
            Console.WriteLine("Email\t:\t" + Email);

        }



    }
}

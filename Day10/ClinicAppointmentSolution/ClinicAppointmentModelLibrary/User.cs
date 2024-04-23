using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentModelLibrary
{

    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        DateTime dob;
        private int age;
        public string Type { get; set; }
        public DateTime Dob
        {

            get => dob;

            set
            {

                dob = value;
                age = ((DateTime.Now - value).Days / 365);

            }
        }

        public User()
        {
            Console.WriteLine("Employee class default constructor");
            Id = 0;
            Name = string.Empty;
            
            Dob = DateTime.Now;
            Type = string.Empty;
        }


        public User(int id, string name, DateTime dob)
        {
            Id = id;
            Name = name;
            Dob = dob;
            Age = age;
        }

        public int Age { get => age; set { age = value; } }

        public virtual void BuildUserFromConsole()
        {
            Console.WriteLine("Please enter the Name");
            Name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please enter the Date of birth");
            Dob = Convert.ToDateTime(Console.ReadLine());
            
        }

        public virtual void PrintDetails()
        {

            Console.WriteLine("Id\t: " + Id);
            Console.WriteLine("Name\t: " + Name);
            Console.WriteLine("Age \t: " + Age); 

        }

        public override bool Equals(object? obj)
        {
            User e1, e2;
            e1 = this;
            //e2 = (Employee)obj;//Casting
            e2 = obj as User;//Casting in a more symanctic way
            return e1.Name.Equals(e2.Name);
        }


    }
}

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

        private int age;
        public string Type { get; set; }
        public DateTime Dob
        {

            get => Dob;

            set
            {

                Dob = value;
                age = ((DateTime.Now - value).Days / 365);

            }
        }

        public User()
        {
            Console.WriteLine("Employee class default constructor");
            Id = 0;
            Name = string.Empty;
            
            Dob = new DateTime();
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



    }
}

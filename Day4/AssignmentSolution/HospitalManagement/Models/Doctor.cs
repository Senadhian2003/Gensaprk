using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    class Doctor
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }

        public Doctor(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Docot Constructor
        /// </summary>
        /// <param name="id">Id of Doctor</param>
        /// <param name="name">Name of Doctor</param>
        /// <param name="age">Age of Doctor</param>
        /// <param name="experience">Experience of Doctor</param>
        /// <param name="qualification">Qualification of Doctor</param>
        /// <param name="speciality">Specialization of Doctor</param>
        public Doctor(int id, string name, int age, int experience, string qualification, string speciality) : this(id)
        {
            Name = name;
            Age = age;
            Experience = experience;
            Qualification = qualification;
            Speciality = speciality;
        }

        /// <summary>
        /// Print Details of Doctor
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Name\t:\t{Name}");
            Console.WriteLine($"Age\t:\t{Age}");
            Console.WriteLine($"Experience\t:\t{Experience}");
            Console.WriteLine($"Qualification\t:\t{Qualification}");
            Console.WriteLine($"Specialization\t:\t{Speciality}");
            Console.WriteLine("----------------------------------------");

        }


    }
}

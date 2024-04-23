using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentModelLibrary
{
    public class Patient : User
    {

        public string Disease { get; set; }
        public Patient() {
            Type = "Patient";
        }

        public Patient(int id)
        {
            Id = id;
        }

        public Patient(int id, string name,  DateTime dob, string disease) : base(id, name, dob)
        {
            Disease = disease;
        }


        public override void BuildUserFromConsole()
        {
            base.BuildUserFromConsole();
            Console.WriteLine("Enter patient disease");
            Disease = Console.ReadLine();
        }




    }
}

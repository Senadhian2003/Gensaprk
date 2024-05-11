using System;
using System.Collections.Generic;

namespace ClinicAppointmentDALLibrary.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string? Qualification { get; set; }
        public string? Specialization { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

        public void PrintDetails()
        {

            Console.WriteLine("Name\t: " + Name);
            Console.WriteLine("Id\t: " + Id);
            Console.WriteLine("Specialization\t: " + Specialization);
            Console.WriteLine("Qualification\t: " + Qualification);
        }
    }
}

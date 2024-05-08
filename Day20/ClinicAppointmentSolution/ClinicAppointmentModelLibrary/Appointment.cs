using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentModelLibrary
{
    public class Appointment
    {
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set;}

        public string Status { get; set; }

        public Appointment()
        {
            Id = 0;
            Title = string.Empty;
            Description = string.Empty;
            Date = DateTime.MinValue;
            Status = "Not approved";
        }

        public override bool Equals(object? obj)
        {
            Appointment e1, e2;
            e1 = this;
            //e2 = (Employee)obj;//Casting
            e2 = obj as Appointment;//Casting in a more symanctic way
            return e1.Id.Equals(e2.Id);
        }



    }
}

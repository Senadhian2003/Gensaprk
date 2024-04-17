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

        public DateTime CreatedDate { get; set;}

        public Appointment()
        {
            Id = 0;
            Title = string.Empty;
            Description = string.Empty;
            CreatedDate = DateTime.Now;
        }





    }
}

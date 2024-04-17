using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary
{
    public interface IAppointmentServices
    {
        Appointment AddAppointment(Appointment appointment);
        Appointment UpdateAppointment(Appointment appointment);
        Appointment DeleteAppointment(Appointment appointment);
        Appointment GetAppointmentByName(string name);
        Appointment GetAppointmentById(int id);

        Appointment RequestAppointmentDateChange(Appointment appointment);
        List<Appointment> GetAllAppointments();

    }
}

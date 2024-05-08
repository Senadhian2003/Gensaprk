using ClinicAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary
{
    public interface IAppointmentServices
    {
        int RequestAppointment(Appointment appointment);
        Appointment UpdateAppointment(int id);
     
        Appointment GetAppointmentById(int id);

        //Appointment RequestAppointmentDateChange(Appointment appointment);
        List<Appointment> GetAllAppointments();

    }
}

using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary
{
    public interface IDoctorServices
    {
        Doctor AddDoctor(Doctor doctor);

        Appointment RequestChangeAppointmentDate(Appointment appointment);

        Doctor GetDoctortById(int id);
        List<Doctor> GetAllDoctors();

        Doctor GetDoctorByName(string name);

        Doctor UpdateDoctorDetails(int id, Doctor doctor);

        Doctor DeleteDoctorDetails(int id);
    }
}

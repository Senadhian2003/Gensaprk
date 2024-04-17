using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary
{
    public interface IPatientServices
    {
        Patient AddPatient(Patient patient);

        Appointment RequestChangeAppointmentDate(Appointment appointment);

        Patient GetPatientById(int id);
        List<Patient> GetAllPatients();

        Patient GetPatientByName(string name);

        Patient UpdatePatientDetails(int id, Patient patient);

        Patient DeletePatientDetails(int id);


    }
}

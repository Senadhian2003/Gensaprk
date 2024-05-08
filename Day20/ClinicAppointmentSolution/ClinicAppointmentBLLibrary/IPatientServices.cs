using ClinicAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary
{
    public interface IPatientServices
    {
        int AddPatient(Patient patient);
        Patient GetPatientById(int id);
        List<Patient> GetAllPatients();
        Patient GetPatientByName(string name);
        Patient ChangePatientName(string oldName, string newName);




    }
}

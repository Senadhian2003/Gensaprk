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
        int AddDoctor(Doctor doctor);

      

        Doctor GetDoctorById(int id);
        List<Doctor> GetAllDoctors();

        Doctor GetDoctorByName(string name);

        Doctor ChangeDoctorName(string oldName, string newName);


    }
}

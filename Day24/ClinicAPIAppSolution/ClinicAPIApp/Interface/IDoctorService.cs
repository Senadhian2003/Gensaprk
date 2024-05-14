using ClinicAPIApp.Models;

namespace ClinicAPIApp.Interface
{
    public interface IDoctorService
    {

        Task<int> AddDoctor(Doctor doctor);

        Task<Doctor> UpdateDoctorSpeciality(int id, string speciality);
        
        Task<IList<Doctor>> GetDoctors();

        Task<IList<Doctor>> GetDoctorsBySpeciality(string speciality);

    }
}

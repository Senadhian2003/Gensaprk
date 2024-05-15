using ClinicAPIApp.Models;

namespace ClinicAPIApp.Interface
{
    public interface IDoctorService
    {

        Task<int> AddDoctor(Doctor doctor);

        Task<Doctor> UpdateDoctorExperience(int id, int experience);
        
        Task<IList<Doctor>> GetDoctors();

        Task<IList<Doctor>> GetDoctorsBySpeciality(string speciality);

    }
}

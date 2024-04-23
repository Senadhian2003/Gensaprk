using ClinicAppointmentDALLibrary;
using ClinicAppointmentModelLibrary;
using RequestTrackerBLLibrary;

namespace ClinicAppointmentBLLibrary
{
    public class DoctorBL : IDoctorServices
    {
        readonly IRepositoryInterface<int, Doctor> _doctorRepository;
        public DoctorBL(IRepositoryInterface<int, Doctor> doctorRepository) {
            _doctorRepository = doctorRepository;
        }
        public int AddDoctor(Doctor doctor)
        {
            var result = _doctorRepository.Add(doctor);

            if(result != null)
            {
                return result.Id;
            }

            throw new DuplicateNameException("Doctor");
            
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctorList;

            doctorList = _doctorRepository.GetAll();

            if (doctorList != null)
            {
                return doctorList;
            }

            throw new EmptyListException("Doctor");
        }

        public Doctor GetDoctorByName(string name)
        {
            List<Doctor> doctorList = _doctorRepository.GetAll();

            foreach (Doctor doctor in doctorList)
            {
                if (doctor.Name == name)
                {
                    return doctor;
                }

            }

            throw new ElementNotFoundException("Doctor");
        }

        public Doctor GetDoctorById(int id)
        {
            Doctor doctor;

            doctor = _doctorRepository.Get(id);

            if (doctor != null)
            {
                return doctor;
            }


            throw new ElementNotFoundException("Doctor");
        }


        public Doctor ChangeDoctorName(string oldName, string newName)
        {
            Doctor doctor;
            if (oldName == newName)
            {
                Console.WriteLine("The doctor old name and new name are same. There is no need to change");
                doctor = GetDoctorByName(oldName);
                return doctor;
            }
            else
            {
                doctor = GetDoctorByName(oldName);
                doctor.Name = newName;
                doctor = _doctorRepository.Update(doctor);

            }

            if (doctor != null)
            {
                return doctor;

            }

            throw new ElementNotFoundException("Doctor");
        }
    }
}

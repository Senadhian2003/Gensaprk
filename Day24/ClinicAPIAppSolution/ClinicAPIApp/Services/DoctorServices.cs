using ClinicAPIApp.Exceptions;
using ClinicAPIApp.Interface;
using ClinicAPIApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPIApp.Services
{
    public class DoctorServices : IDoctorService
    {
        IRepository<int, Doctor> _repository;
        public DoctorServices(IRepository<int, Doctor> repository)
        {
            _repository = repository;
        }

        public async Task<int> AddDoctor(Doctor doctor)
        {
            Doctor doctor1 = await _repository.Add(doctor);
            if(doctor1 != null)
            {
                return doctor1.Id;
            }
            throw new NotImplementedException();
        }

        public async Task<IList<Doctor>> GetDoctors()
        {

            return await _repository.GetAll();

           
        }

        public async Task<IList<Doctor>> GetDoctorsBySpeciality(string speciality)
        {
            var doctors = await _repository.GetAll();

            List<Doctor> doctorsWithSpeciality = new List<Doctor>();

            foreach(var doctor in doctors)
            {
                if(doctor.Specialization == speciality)
                {
                    doctorsWithSpeciality.Add(doctor);
                }
            }

            if(doctorsWithSpeciality.Count > 0)
            {
                return doctorsWithSpeciality;
            }


            throw new EmptyListException("Doctors");
        }

        public async Task<Doctor> UpdateDoctorExperience(int id, int experience)
        {
            Doctor doctor = await _repository.GetByKey(id);

            if(doctor != null)
            {
                doctor.Experience = experience;
                await _repository.Update(doctor);
                return doctor;
            }

            throw new ElementNotFoundException("Doctor");
        }

      


    }
}

using ClinicAppointmentDALLibrary;
using ClinicAppointmentDALLibrary.Model;
using RequestTrackerBLLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary
{
    public class PatientBL : IPatientServices
    {
        readonly IRepositoryInterface<int, Patient> _patientRepository;
        public PatientBL()
        {
            _patientRepository = new PatientRepository(new ClinicManagementContext());
        }
        public int AddPatient(Patient patient)
        {
            var result = _patientRepository.Add(patient);

            if (result != null)
            {
                return result.Id;
            }

            throw new DuplicateNameException("Patient");

        }

        public List<Patient> GetAllPatients()
        {
            List<Patient> patientList;

            patientList = _patientRepository.GetAll();

            if (patientList != null)
            {
                return patientList;
            }

            throw new EmptyListException("Patient");
        }

        public Patient GetPatientByName(string name)
        {
            List<Patient> patientList = _patientRepository.GetAll();

            foreach (Patient patient in patientList)
            {
                if (patient.Name == name)
                {
                    return patient;
                }

            }

            throw new ElementNotFoundException("Patient");
        }

        public Patient GetPatientById(int id)
        {
            Patient patient;

            patient = _patientRepository.GetById(id);

            if (patient != null)
            {
                return patient;
            }


            throw new ElementNotFoundException("Patient");
        }


        public Patient ChangePatientName(string oldName, string newName)
        {
            Patient patient;
            if (oldName == newName)
            {
                Console.WriteLine("The patient old name and new name are same. There is no need to change");
                patient = GetPatientByName(oldName);
                return patient;
            }
            else
            {
                patient = GetPatientByName(oldName);
                patient.Name = newName;
                patient = _patientRepository.Update(patient);

            }

            if (patient != null)
            {
                return patient;

            }

            throw new ElementNotFoundException("Patient");
        }
    }
}

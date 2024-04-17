using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentDALLibrary
{
    public class PatientRepository : IRepositoryInterface<int,Patient>
    {
        readonly Dictionary<int, Patient> _patients;

        public PatientRepository()
        {
            _patients = new Dictionary<int, Patient>();
        }

        int GenerateId()
        {
            if (_patients.Count == 0)
                return 1;
            int id = _patients.Keys.Max();
            return ++id;
        }

        public Patient Add(Patient item)
        {
            if (_patients.ContainsValue(item))
            {
                return null;
            }

            _patients[GenerateId()] = item;
            return item;
        }

        public Patient Delete(int key)
        {
            if (_patients.ContainsKey(key))
            {
                var doctor = _patients[key];
                _patients.Remove(key);
                return doctor;
            }
            return null;
        }

        public Patient Get(int key)
        {
            if (_patients.ContainsKey(key))
            {
                return _patients[key];
            }
            return null;
        }

        public List<Patient> GetAll()
        {
            if (_patients.Count == 0)
            {
                return null;
            }
            return _patients.Values.ToList();
        }

        public Patient Update(int key, Patient item)
        {
            if (!_patients.ContainsKey(key))
            {
                return null;
            }

            _patients[key] = item;
            return item;
        }
    }
}

using ClinicAppointmentModelLibrary;

namespace ClinicAppointmentDALLibrary
{
    public class DoctorRepository : IRepositoryInterface<int, Doctor>
    {

        readonly Dictionary<int, Doctor> _doctors;

        public DoctorRepository()
        {
            _doctors = new Dictionary<int, Doctor>();
        }

        int GenerateId()
        {
            if (_doctors.Count == 0)
                return 1;
            int id = _doctors.Keys.Max();
            return ++id;
        }

        public Doctor Add(Doctor item)
        {
            if (_doctors.ContainsValue(item))
            {
                return null;
            }

            _doctors[GenerateId()] = item;
            return item;
        }

        public Doctor Delete(int key)
        {
            if (_doctors.ContainsKey(key))
            {
                var doctor = _doctors[key];
                _doctors.Remove(key);
                return doctor;
            }
            return null;
        }

        public Doctor Get(int key)
        {
            if (_doctors.ContainsKey(key))
            {
                return _doctors[key];
            }
            return null;
        }

        public List<Doctor> GetAll()
        {
            if(_doctors.Count == 0)
            {
                return null;
            }
            return _doctors.Values.ToList();
        }

        public Doctor Update(int key, Doctor item)
        {
            if (!_doctors.ContainsKey(key))
            {
                return null;
            }

            _doctors[key] = item;
            return item;
        }
    }
}

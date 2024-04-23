using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentDALLibrary
{
    public class AppointmentRepository : IRepositoryInterface<int, Appointment>
    {
        readonly Dictionary<int, Appointment> _appointments;

        public AppointmentRepository()
        {
            _appointments = new Dictionary<int, Appointment>();
        }

        int GenerateId()
        {
            if (_appointments.Count == 0)
                return 1;
            int id = _appointments.Keys.Max();
            return ++id;
        }

        public Appointment Add(Appointment item)
        {
            if (_appointments.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _appointments.Add(GenerateId(), item);
            return item;
        }

        public Appointment Delete(int key)
        {
            if (_appointments.ContainsKey(key))
            {
                var doctor = _appointments[key];
                _appointments.Remove(key);
                return doctor;
            }
            return null;
        }

        public Appointment Get(int key)
        {
            if (_appointments.ContainsKey(key))
            {
                return _appointments[key];
            }
            return null;
        }

        public List<Appointment> GetAll()
        {
            if (_appointments.Count == 0)
            {
                return null;
            }
            return _appointments.Values.ToList();
        }

        public Appointment Update(Appointment item)
        {
            if (!_appointments.ContainsKey(item.Id))
            {
                return null;
            }

            _appointments[item.Id] = item;
            return item;
        }

    }
}

using ClinicAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentDALLibrary
{
    public class AppointmentRepository : IRepositoryInterface<int, Appointment>
    {
        

        readonly ClinicManagementContext _context;

        public AppointmentRepository(ClinicManagementContext context)
        {
            _context = context;
        }

        //int GenerateId()
        //{
        //    if (_patients.Count == 0)
        //        return 1;
        //    int id = _patients.Keys.Max();
        //    return ++id;
        //}

        public Appointment Add(Appointment item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Appointment DeleteById(int key)
        {
            Appointment appointment = GetById(key);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();

            }
            return null;
        }

        public Appointment GetById(int key)
        {
            Appointment appointment = _context.Appointments.FirstOrDefault(p => p.Id == key);

            return appointment;
        }

        public List<Appointment> GetAll()
        {

            return _context.Appointments.ToList();
        }

        public Appointment Update(Appointment item)
        {
            Appointment appointment = GetById(item.Id);

            if (appointment != null)
            {
                _context.Appointments.Update(appointment);
                _context.SaveChanges();
                return appointment;
            }


            return null;
        }

    }
}

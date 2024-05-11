using ClinicAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentDALLibrary
{
    public class PatientRepository : IRepositoryInterface<int,Patient>
    {
        readonly ClinicManagementContext _context;

        public PatientRepository(ClinicManagementContext context)
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

        public Patient Add(Patient item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Patient DeleteById(int key)
        {
            Patient patient = GetById(key);
            if(patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();

            }
            return null;
        }

        public Patient GetById(int key)
        {
            Patient patient = _context.Patients.FirstOrDefault(p=>p.Id==key);

            return patient;
        }

        public List<Patient> GetAll()
        {
            
            return _context.Patients.ToList();
        }

        public Patient Update(Patient item)
        {
            Patient patient = GetById(item.Id);

            if(patient != null)
            {
             _context.Patients.Update(patient); 
                _context.SaveChanges();
                return patient;
            }

            
            return null;
        }
    }
}

using ClinicAppointmentDALLibrary.Model;

namespace ClinicAppointmentDALLibrary
{
    public class DoctorRepository : IRepositoryInterface<int, Doctor>
    {

        readonly ClinicManagementContext _context;

        public DoctorRepository(ClinicManagementContext context)
        {
            _context = context;
        }

        //int GenerateId()
        //{
        //    if (_doctors.Count == 0)
        //        return 1;
        //    int id = _doctors.Keys.Max();
        //    return ++id;
        //}

        public  Doctor Add(Doctor item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Doctor DeleteById(int key)
        {
           Doctor doctor = GetById(key);
            if (doctor != null)
            {
                _context.Remove(doctor);
                _context.SaveChanges();
            }
            return doctor;
        }

        public Doctor GetById(int key)
        {
            Doctor doctor = _context.Doctors.FirstOrDefault(d=>d.Id==key);
            return doctor;
        }

        public List<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public Doctor Update( Doctor item)
        {
            Doctor doctor = GetById(item.Id);

            if (doctor != null)
            {
                _context.Update(item);
                _context.SaveChanges();
            }
            return item;
        }

       
    }
}

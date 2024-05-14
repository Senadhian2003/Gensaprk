using ClinicAPIApp.Contexts;
using ClinicAPIApp.Exceptions;
using ClinicAPIApp.Interface;
using ClinicAPIApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ClinicAPIApp.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {

        private readonly ClinicManagementContext _context;
        public DoctorRepository(ClinicManagementContext context) {
            _context = context;
        }

        public async Task<Doctor> Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;

        }


        public async Task<Doctor> GetByKey(int id)
        {
            Doctor doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);

            if (doctor != null)
            {
                return doctor;
            }

            throw new ElementNotFoundException("Doctor");

        }

        public async Task<Doctor> Update(Doctor doctor)
        {
            Doctor doc = await GetByKey(doctor.Id);
            _context.Doctors.Update(doctor);
             await _context.SaveChangesAsync();
             return doctor;

        }

        public async Task<IList<Doctor>> GetAll()
        {
            List<Doctor> doctors = await _context.Doctors.ToListAsync();

            if(doctors.Count >= 0)
            {
                return doctors;
            }

            throw new EmptyListException("Doctors");

        }


        public async Task<Doctor> DeleteByKey(int id)
        {
            Doctor doc = await GetByKey(id);

            _context.Doctors.Remove(doc);
            await _context.SaveChangesAsync();
            return doc;

        }



    }
}

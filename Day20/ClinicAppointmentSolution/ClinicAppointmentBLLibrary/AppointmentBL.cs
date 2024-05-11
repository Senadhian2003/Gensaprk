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
    public class AppointmentBL : IAppointmentServices
    {
        readonly IRepositoryInterface<int, Appointment> _appointmentRepository;
        public AppointmentBL() {
            _appointmentRepository = new AppointmentRepository(new ClinicManagementContext());
        }

        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointmentList;

            appointmentList = _appointmentRepository.GetAll();

            if (appointmentList != null)
            {
                return appointmentList;
            }

            throw new EmptyListException("Appointment");
        }

        public Appointment GetAppointmentById(int id)
        {
            Appointment appointment;

            appointment = _appointmentRepository.GetById(id);

            if (appointment != null)
            {
                return appointment;
            }


            throw new ElementNotFoundException("Appointment");
        }

        public int RequestAppointment(Appointment appointment)
        {
            var result = _appointmentRepository.Add(appointment);

            if (result != null)
            {
                return result.Id;
            }

            throw new DuplicateNameException("Appointment");
        }

        public Appointment UpdateAppointment(int id)
        {
            Appointment result = GetAppointmentById(id);

            Console.WriteLine("Enter date of appointment");
            DateTime date = Convert.ToDateTime( Console.ReadLine());
            result.DateOfAppointment = date;
            result.Status = "Approved";
            
            result = _appointmentRepository.Update(result);

            if (result != null)
            {
                return result;
            }
            throw new ElementNotFoundException("Appointment") ;
            
        }
    }
}

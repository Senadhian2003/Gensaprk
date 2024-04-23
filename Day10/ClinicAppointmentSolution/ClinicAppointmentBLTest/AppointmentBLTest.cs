using ClinicAppointmentBLLibrary;
using ClinicAppointmentDALLibrary;
using ClinicAppointmentModelLibrary;
using RequestTrackerBLLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLTest
{
    public class AppointmentBLTest
    {
        IRepositoryInterface<int, Appointment> repository;
        IAppointmentServices appointmentService;
        [SetUp]
        public void Setup()
        {
            repository = new AppointmentRepository();
            appointmentService = new AppointmentBL(repository);

        }

        [Test]
        public void AddAppointment()
        {
            Appointment doc = new Appointment() { Description = "Batman" };
            int id = appointmentService.RequestAppointment(doc);

            Assert.AreEqual(1, id);
        }

      
        [Test]
        public void GetAllAppointmentsFail()
        {
            List<Appointment> appointments;
            var exception = Assert.Throws<EmptyListException>(() => appointmentService.GetAllAppointments());
            Assert.AreEqual("The Appointment list is empty", exception.Message);

        }

        [Test]
        public void GetAllAppointments()
        {
            Appointment doc = new Appointment() { Description = "Sena" };
            int id = appointmentService.RequestAppointment(doc);
            List<Appointment> appointments;
            int len = appointmentService.GetAllAppointments().Count();
            Assert.AreEqual(1, len);

        }

      
        [Test]
        public void GetAppointmentById()
        {
            Appointment doc = new Appointment() { Description = "Sena" };
            appointmentService.RequestAppointment(doc);

            Appointment appointment = appointmentService.GetAppointmentById(1);
            Assert.IsNotNull(appointment);


        }

        [Test]
        public void GetAppointmentByIdFail()
        {
            var expression = Assert.Throws<ElementNotFoundException>(() => appointmentService.GetAppointmentById(2));

            Assert.AreEqual("The Appointment could not be found", expression.Message);
        }



    }
}

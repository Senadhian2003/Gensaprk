using ClinicAppointmentBLLibrary;
using ClinicAppointmentModelLibrary;
using ClinicAppointmentDALLibrary;
using RequestTrackerBLLibrary;

namespace ClinicAppointmentBLTest
{
    public class Test
    {
        IRepositoryInterface<int, Patient> repository;
        IPatientServices patientService;
        [SetUp]
        public void Setup()
        {
            repository = new PatientRepository();
            patientService = new PatientBL(repository);

        }

        [Test]
        public void AddPatient()
        {
            Patient doc = new Patient() { Name = "Batman" };
            int id = patientService.AddPatient(doc);

            Assert.AreEqual(1, id);
        }

        [Test]
        public void AddPatientFailTest()
        {
            Patient doc = new Patient() { Name = "Sena" };
            int id = patientService.AddPatient(doc);
            doc = new Patient() { Name = "Sena" };
            //id = patientService.AddPatient(doc);

            var exception = Assert.Throws<DuplicateNameException>(() => patientService.AddPatient(doc));
            //Assert
            Assert.AreEqual("Patient name already exists", exception.Message);
        }

        [Test]
        public void GetAllPatientsFail()
        {
            List<Patient> patients;
            var exception = Assert.Throws<EmptyListException>(() => patientService.GetAllPatients());
            Assert.AreEqual("The Patient list is empty", exception.Message);

        }

        [Test]
        public void GetAllPatients()
        {
            Patient doc = new Patient() { Name = "Sena" };
            int id = patientService.AddPatient(doc);
            List<Patient> patients;
            int len = patientService.GetAllPatients().Count();
            Assert.AreEqual(1, len);

        }

        [Test]
        public void GetPatientByName()
        {
            Patient doc = new Patient() { Name = "Sena" };
            patientService.AddPatient(doc);

            Patient patient = patientService.GetPatientByName("Sena");
            Assert.IsNotNull(patient);

        }

        [Test]
        public void GetPatientByNameFail()
        {
            Patient doc = new Patient() { Name = "Sena" };
            patientService.AddPatient(doc);

            var expression = Assert.Throws<ElementNotFoundException>(() => patientService.GetPatientByName("Spiderman"));

            Assert.AreEqual("The Patient could not be found", expression.Message);

        }

        [Test]
        public void GetPatientById()
        {
            Patient doc = new Patient() { Name = "Sena" };
            patientService.AddPatient(doc);

            Patient patient = patientService.GetPatientById(1);
            Assert.IsNotNull(patient);


        }

        [Test]
        public void GetPatientByIdFail()
        {
            var expression = Assert.Throws<ElementNotFoundException>(() => patientService.GetPatientById(2));

            Assert.AreEqual("The Patient could not be found", expression.Message);
        }

        [Test]
        public void ChangePatientName()
        {
            Patient doc = new Patient() { Name = "Sena" };
            patientService.AddPatient(doc);

            doc = patientService.ChangePatientName("Sena", "Spiderman");

            Assert.IsNotNull(doc);

        }

        [Test]
        public void ChangePatientNameFail()
        {
            Patient doc = new Patient() { Name = "Sena" };
            patientService.AddPatient(doc);

            var exception = Assert.Throws<ElementNotFoundException>(() => patientService.ChangePatientName("Goku", "Spiderman"));
            Assert.AreEqual("The Patient could not be found", exception.Message);


        }



    }
}

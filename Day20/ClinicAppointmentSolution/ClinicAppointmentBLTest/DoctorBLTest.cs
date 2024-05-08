using ClinicAppointmentBLLibrary;
using ClinicAppointmentModelLibrary;
using ClinicAppointmentDALLibrary;
using RequestTrackerBLLibrary;

namespace ClinicAppointmentBLTest
{
    public class Tests
    {
        IRepositoryInterface<int, Doctor> repository;
        IDoctorServices doctorService;
        [SetUp]
        public void Setup()
        {
            repository = new DoctorRepository();
            doctorService = new DoctorBL(repository);
            
        }

        [Test]
        public void AddDoctor()
        {
            Doctor doc = new Doctor() { Name = "Batman" };
            int id = doctorService.AddDoctor(doc);
            
            Assert.AreEqual(1, id);
        }

        [Test]
        public void AddDoctorFailTest()
        {
            Doctor doc = new Doctor() { Name = "Sena" };
            int id = doctorService.AddDoctor(doc);
             doc = new Doctor() { Name = "Sena" };
            //id = doctorService.AddDoctor(doc);

            var exception = Assert.Throws<DuplicateNameException>(() => doctorService.AddDoctor(doc));
            //Assert
            Assert.AreEqual("Doctor name already exists", exception.Message);
        }

        [Test]
        public void GetAllDoctorsFail()
        {
            List<Doctor> doctors;
            var exception = Assert.Throws<EmptyListException>(() => doctorService.GetAllDoctors());
            Assert.AreEqual("The Doctor list is empty", exception.Message);

        }

        [Test]
        public void GetAllDoctors()
        {
            Doctor doc = new Doctor() { Name = "Sena" };
            int id = doctorService.AddDoctor(doc);
            List<Doctor> doctors;
            int len = doctorService.GetAllDoctors().Count();
            Assert.AreEqual(1,len);

        }

        [Test]
        public void GetDoctorByName()
        {
            Doctor doc = new Doctor() { Name = "Sena" };
            doctorService.AddDoctor(doc);

            Doctor doctor = doctorService.GetDoctorByName("Sena");
            Assert.IsNotNull(doctor);

        }

        [Test]
        public void GetDoctorByNameFail()
        {
            Doctor doc = new Doctor() { Name = "Sena" };
            doctorService.AddDoctor(doc);

            var expression = Assert.Throws<ElementNotFoundException>(() => doctorService.GetDoctorByName("Spiderman"));

            Assert.AreEqual("The Doctor could not be found",expression.Message);

        }

        [Test]
        public void GetDoctorById()
        {
            Doctor doc = new Doctor() { Name = "Sena" };
            doctorService.AddDoctor(doc);

            Doctor doctor = doctorService.GetDoctorById(1);
            Assert.IsNotNull(doctor);


        }

        [Test]
        public void GetDoctorByIdFail() {
            var expression = Assert.Throws<ElementNotFoundException>(() => doctorService.GetDoctorById(2));

            Assert.AreEqual("The Doctor could not be found", expression.Message);
        }

        [Test]
        public void ChangeDoctorName()
        {
            Doctor doc = new Doctor() { Name = "Sena" };
            doctorService.AddDoctor(doc);

            doc = doctorService.ChangeDoctorName("Sena", "Spiderman");

            Assert.IsNotNull(doc);

        }

        [Test]
        public void ChangeDoctorNameFail()
        {
            Doctor doc = new Doctor() { Name = "Sena" };
            doctorService.AddDoctor(doc);

            var exception = Assert.Throws<ElementNotFoundException>(() => doctorService.ChangeDoctorName("Goku", "Spiderman"));
            Assert.AreEqual("The Doctor could not be found", exception.Message);


        }

    


    }
}
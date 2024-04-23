using ClinicAppointmentBLLibrary;
using ClinicAppointmentDALLibrary;
using ClinicAppointmentModelLibrary;

namespace ClinicAppointmentApp
{
    internal class Program
    {
        DoctorRepository doctorRepository = new DoctorRepository();
        DoctorBL doctorService ;

        public Program()
        {
            doctorService = new DoctorBL(doctorRepository);
        }

        void AddDoc()
        {
            Doctor doc = new Doctor() { Name = "Sena" };
            int id = doctorService.AddDoctor(doc);
            Console.WriteLine(id);
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            program.AddDoc();  
        }
    }
}

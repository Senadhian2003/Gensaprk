using ClinicAppointmentBLLibrary;
using ClinicAppointmentDALLibrary;
using ClinicAppointmentDALLibrary.Model;
//using Microsoft.EntityFrameworkCore.Design;
namespace ClinicAppointmentApp
{
    internal class Program
    {
        
        DoctorBL doctorService ;

        public Program()
        {
            doctorService = new DoctorBL();
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

            Doctor doctor = program.doctorService.GetDoctorByName("S"); 
            doctor.PrintDetails();
        }
    }
}

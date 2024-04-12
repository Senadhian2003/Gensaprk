using HospitalManagement.Models;
using System.Text.RegularExpressions;

namespace HospitalManagement
{
    class Program
    {
     
        /// <summary>
        /// Validate and get string as input
        /// </summary>
        /// <param name="input">The input given to Function</param>
        /// <param name="output">The output of the string after validation </param>
        /// <returns></returns>
        static bool getString(string input, out string output)
        {
            output = "";

            string pattern = @"^[a-zA-Z\s]+$";
            if(Regex.IsMatch(input, pattern) && input.Length>0 )
            {
                output = input.Trim();
                return true;
            }
            return false;

        }

       
        /// <summary>
        /// Obtain Details of the Doctor
        /// </summary>
        /// <param name="id">Id of the Doctor</param>
        /// <returns></returns>
        Doctor getDocotorDetails(int id)
        {
            Doctor doctor = new Doctor(100 + id);
            Console.WriteLine("Enter Doctor Name");
            string name;
            while (!getString(Console.ReadLine(), out name))
            {
                Console.WriteLine("Invalid Doctor name. Type again");
            }
            doctor.Name = name;

            Console.WriteLine("Enter Age");
            int age;
           
            while (!(int.TryParse(Console.ReadLine(), out age) ) || (age < 0)) {
                Console.WriteLine("Invalid age type again");
            }

            Console.WriteLine("Enter Experience");
            int experience;

            while (!(int.TryParse(Console.ReadLine(), out experience)))
            {
                Console.WriteLine("Invalid experince type again");
            }
            doctor.Experience = experience;

            Console.WriteLine("Enter Qualification");
            string qualification;
            while (!getString(Console.ReadLine(), out qualification))
            {
                Console.WriteLine("Invalid Qualification. Type again");
            }
            doctor.Qualification = qualification;

            Console.WriteLine("Enter Specialization");
            string specialization;
            while (!getString(Console.ReadLine(), out specialization))
            {
                Console.WriteLine("Invalid Specialization. Type again");
            }
            doctor.Speciality = specialization;

            return doctor;


        }

        

        static void printAllDoctors(Doctor[] doctors)
        {
            int len = doctors.Length;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Doctor Details");
            for (int i = 0; i < len; i++)
            {
                doctors[i].PrintInfo();
                Console.WriteLine("************************************");
            }
            Console.WriteLine("--------------------------------------------------------");
        }

        static void printDoctorsWithSpeciality(Doctor[] doctors)
        {
            Console.WriteLine("Enter Specialization");
            string speciality;

            while (!getString(Console.ReadLine(), out speciality))
            {
                Console.WriteLine("Invalid Specialization. Type again");
            }

            int len = doctors.Length;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("The doctors with required specialization are...");
            for( int i = 0; i < len; i++)
            {
                if (doctors[i].Speciality == speciality)
                {
                    doctors[i].PrintInfo();
                }
                Console.WriteLine("*****************************************************");
            }
            Console.WriteLine("--------------------------------------------------------");
        }


        static void Main(string[] args)
        {
            Program program = new Program();    
            Doctor[] doctors = new Doctor[3];

            int len = doctors.Length;
            for (int i = 0; i < doctors.Length; i++)
            {
                doctors[i] = program.getDocotorDetails(i);
            }
            printAllDoctors(doctors);

            printDoctorsWithSpeciality(doctors);


        }
    }
}

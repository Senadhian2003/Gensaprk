using System.Data;

namespace ClinicAppointmentModelLibrary
{
    public class Doctor : User
    {
        

        public string Qualification { get; set; }
        public string Specialization { get; set; }
        
        public Doctor()
        {
            Type = "Doctor";
        }
        public Doctor(int id)
        {
            Id = id;
        }

        public Doctor(int id, string name, DateTime dob, string qualification, string specialization) : base (id,name,dob)
        {
            
            Qualification = qualification;
            Specialization = specialization;
        }


        public override void BuildUserFromConsole()
        {
            base.BuildUserFromConsole();
            Console.WriteLine("Enter Doctor Qualification\t: ");
            Qualification = Console.ReadLine();
            Console.WriteLine("Enter Doctor Specialization\t: ");
            Specialization = Console.ReadLine();

        }



        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine("Specialization\t: " + Specialization);
            Console.WriteLine("Qualification\t: " + Qualification);
        }

       



    }
}

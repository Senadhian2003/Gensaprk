namespace RequestTrackerModelLibrary
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public override string ToString()
        {
            return Id + " " + Name + " " + Role;
        }
        public virtual bool PasswordCheck(string password)
        {
            return this.Password == password;
        }
        public ICollection<Request> RequestsRaised { get; set; }//No effect on the table
        public ICollection<Request> RequestsClosed { get; set; }//No effect on the table

        public ICollection<RequestSolution> SolutionsProvided { get; set; }

        public ICollection<SolutionFeedback> FeedbacksGiven { get; set; }

        public void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Enter Your name");
            Name = Console.ReadLine();
            Console.WriteLine("Enter password");
            Password = Console.ReadLine();
            Console.WriteLine("Enter Role\n1.Employee\n2.Admin");
            int option = Convert.ToInt32(Console.ReadLine());

            if(option == 1)
            {
                Role = "Employee";
            }
            else
            {
                Role = "Admin";
            }


        }

        public void PrintMenuForEmployee()
        {
            Console.WriteLine();
            Console.WriteLine("Employee Functionalities");
            Console.WriteLine("1. Raise Request");
            Console.WriteLine("2. View Request status");
            Console.WriteLine("3. View Solutions");
            Console.WriteLine("4. Give Feedback");
            Console.WriteLine("5. Respond to solution");
            Console.WriteLine("0. Logout");
            Console.WriteLine();
        }


    }
}

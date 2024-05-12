

using RequestTrackerBLLibrary;
using RequestTrackerBLLibrary.Interface;
using RequestTrackerModelLibrary;

namespace RequestTrackerFEAPP
{
    internal class RequestTrackerFEAPP
    {
       
        EmployeeLoginBL loginBL;
        Employee employee;
        public RequestTrackerFEAPP()
        {
            loginBL = new EmployeeLoginBL();
            
        }


        async void EmployeeInteraction()
        {
            int choice = 0;
            Console.WriteLine("Select the option.\n1.Login\n2.Register");
            int option = Convert.ToInt32(Console.ReadLine());
            if (option == 1)
            {
                Console.WriteLine("Enter your Id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your Password");
                string password = Console.ReadLine();

                Employee employee = new Employee();

                employee.Id = id;
                employee.Password = password;

                int cnt = 0;
                 bool login = await loginBL.Login(employee) ;
                if(login)
                {
                    employee = await loginBL.GetEmployee(employee) ;
                    Console.WriteLine("Login Successful");
                }
                else
                {
                    Console.WriteLine("Employee Id and Password mismatch");
                }

            }
            else
            {
                Employee emp = new Employee();
                emp.BuildEmployeeFromConsole();
                employee = await loginBL.Register(emp);

            }

            if(employee != null)
            {

                if (employee.Role == "Employee")
                {
                    EmployeeDashboard dashboard = new EmployeeDashboard();
                    dashboard.Interactions();
                }
                else
                {
                    AdminDashboard dashboard = new AdminDashboard();
                    dashboard.Interactions();
                    
                }


            }

            EmployeeInteraction();
            


        }



        static async Task Main(string[] args)
        {

        }


    }
}

using RequestTrackerBLLibrary.BussinessLogics;
using RequestTrackerBLLibrary.Interface;
using RequestTrackerFEAPP.Dashboard;
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


        async Task EmployeeInteraction()
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

                Employee emp = new Employee();

                emp.Id = id;
                emp.Password = password;

                int cnt = 0;
                 bool login = await loginBL.Login(emp) ;
                if(login)
                {
                    employee = await loginBL.GetEmployee(emp) ;
                    Console.WriteLine("Login Successful");
                }
                else
                {
                    Console.WriteLine("Employee Id and Password mismatch");
                }

            }
            else if(option == 2)
            {
                Employee emp = new Employee();
                emp.BuildEmployeeFromConsole();
                employee = await loginBL.Register(emp);
                await Console.Out.WriteLineAsync("User added successfully");

            }
            else
            {
                employee = null;
            }

            if(employee != null)
            {

                if (employee.Role == "Employee")
                {
                    EmployeeDashboard dashboard = new EmployeeDashboard(employee);
                    await dashboard.Interactions();
                }
                else
                {
                    AdminDashboard dashboard = new AdminDashboard(employee);
                    await dashboard.Interactions();

                }


            }

            await EmployeeInteraction();
            


        }



        static async Task Main(string[] args)
        {
            RequestTrackerFEAPP app = new RequestTrackerFEAPP();
            await app.EmployeeInteraction();
        }


    }
}

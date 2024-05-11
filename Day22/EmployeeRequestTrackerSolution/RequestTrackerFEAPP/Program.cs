

using RequestTrackerBLLibrary;
using RequestTrackerBLLibrary.Interface;
using RequestTrackerModelLibrary;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        IEmployeeLoginBL employeeLoginBL;
        IRequestBL requestBl;
        Program() {

            employeeLoginBL = new EmployeeLoginBL();
            requestBl = new RequestBL();
        }
        async Task EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password, Id = username };
            
            var result = await employeeLoginBL.Login(employee);
            if (result)
            {
                await Console.Out.WriteLineAsync("Login Success");
            }
            else
            {
                Console.Out.WriteLine("Invalid username or password");
            }
        }

        async Task EmployeeRegisterAsync()
        {
            Employee employee = new Employee() {Name="Sena",Password="Spider",Role="Dev" };
            await employeeLoginBL.Register(employee);
            Console.WriteLine("Employee Added successfully");
        }

        async Task GetLoginDeatils()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            await EmployeeLoginAsync(id, password);
        }

        async Task AddRequest()
        {
            Request request = new Request() { RequestMessage="xyz", RequestDate=Convert.ToDateTime("03/03/2023"), RequestStatus="Pending", RequestRaisedBy=103, RequestClosedBy= 101  };
            await requestBl.CreateRequest(request);
            Console.WriteLine("Request Added successfully");
        }


        static async Task Main(string[] args)
        {
            await new Program().AddRequest();
        }
    }
}

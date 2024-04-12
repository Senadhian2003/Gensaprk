using ObjectOrientation.Models;

namespace ObjectOrientation
{
    internal class Program
    {

        Employee getEmployeeDetailsFromConsole(int id)
        {
            Employee employee = new Employee(100 + id);
            Console.WriteLine("Enter name");
            employee.Name = Console.ReadLine();
            Console.WriteLine("Enter email");
            employee.Email = Console.ReadLine();
            return employee;
            

        }


        static void Main(string[] args)
        {
            Program program = new Program();
            Employee employee = new Employee(101,"Sena","senadhian@gmail.com");
            employee.Salary = 1000;
           
            Console.WriteLine(employee.Salary);

            ////int[] ages = new int[] { 7, 8 };
            //int[] ages = new int[2];
            //ages[0]= 7;
            ////ages[1]= 8;


            //int len = ages.Length;
            //for(int i = 0; i < len; i++)
            //{
            //    Console.WriteLine(ages[i]);
            //}

            Employee[] employees = new Employee[2];

            for (int i = 0; i < employees.Length; i++)
            {

                employees[i] = program.getEmployeeDetailsFromConsole(i);


            }

            for (int i = 0; i < employees.Length; i++)
            {

                employees[i].printInfo();


            }



        }
    }
}

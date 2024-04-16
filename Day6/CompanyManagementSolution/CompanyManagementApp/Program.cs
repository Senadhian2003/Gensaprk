using CompanyModelLibrary;

namespace CompanyManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();

           Employee employee =  company.GetEmployeeDetails();
            company.GovernmentRules(employee);
            employee.PrintDetails();
        }
    }
}

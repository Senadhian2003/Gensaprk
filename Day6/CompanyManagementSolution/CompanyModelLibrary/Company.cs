namespace CompanyModelLibrary
{
    public class Company
    {

        public void GovernmentRules(GovRules rules)
        {
            Console.WriteLine("Leave Details\t :"+rules.LevDetails());
            Console.WriteLine("Employee Pension Fund\t :"+rules.EmployeePf());
            if (rules.GratuityAmount() == -1)
            {
                Console.WriteLine("Gratuity Not Applicable");
                return;
            }
            Console.WriteLine("Gratuity Amount\t: " + rules.GratuityAmount());
        }

        public Employee GetEmployeeDetails()
        {

            Console.WriteLine("Enter the company of employee");
            string Company = Console.ReadLine();
            Employee employee;
            if (Company == "Accenture")
            {
                employee = new AccentureEmployee(101, "Spiderman", "IT", 100, 15);
            }
            else
            {
                employee = new TcsEmployee(103, "Batman", "HR", 100, 10);
            }
            return employee;

        }


    }
}

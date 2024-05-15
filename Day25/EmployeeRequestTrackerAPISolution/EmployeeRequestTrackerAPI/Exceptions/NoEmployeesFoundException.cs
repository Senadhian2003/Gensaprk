namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoEmployeesFoundException : Exception
    {
        string message;
        public NoEmployeesFoundException() {
            message = "The employee list is empty";
        }

        public override string Message => message;

    }
}

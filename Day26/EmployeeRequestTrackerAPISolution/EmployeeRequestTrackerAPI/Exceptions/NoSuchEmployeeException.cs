namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoSuchEmployeeException : Exception
    {
        string message;

        public NoSuchEmployeeException()
        {
            message = "Employee not found";
        }

        public override string Message => message;

    }
}

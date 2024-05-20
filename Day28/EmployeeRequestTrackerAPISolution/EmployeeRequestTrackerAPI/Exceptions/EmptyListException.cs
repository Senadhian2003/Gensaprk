namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class EmptyListException : Exception
    {
        string message;

        public EmptyListException(string element)
        {
            message = $"The {element} list is empty";
        }

        public override string Message => message;
    }
}

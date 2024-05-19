namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class ElementNotFoundException : Exception
    {
        string message;

        public ElementNotFoundException(string element)
        {
            message = $"The {element} is not found";
        }

        public override string Message => message;

    }
}

namespace ClinicAPIApp.Exceptions
{
    public class ElementNotFoundException : Exception
    {
        string message;

        public ElementNotFoundException(string element)
        {
            message = $"The {element} could not be found";
        }

        public override string Message => message;

    }
}

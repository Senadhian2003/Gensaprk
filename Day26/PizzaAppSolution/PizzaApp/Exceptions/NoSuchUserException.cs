namespace PizzaApp.Exceptions
{
    public class NoSuchUserException : Exception
    {
        string message;

        public NoSuchUserException()
        {
            message = "Employee not found";
        }

        public override string Message => message;
    }
}

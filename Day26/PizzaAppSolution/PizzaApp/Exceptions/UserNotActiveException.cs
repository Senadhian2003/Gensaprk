namespace PizzaApp.Exceptions
{
    public class UserNotActiveException : Exception
    {
        string message;
        public UserNotActiveException(string data)
        {

            message = data;
        }

        public override string Message => message;
    }
}

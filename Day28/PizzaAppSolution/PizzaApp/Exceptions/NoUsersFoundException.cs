namespace PizzaApp.Exceptions
{
    public class NoUsersFoundException : Exception
    {

        string message;
        public NoUsersFoundException()
        {
            message = "The employee list is empty";
        }

        public override string Message => message;
    }
}

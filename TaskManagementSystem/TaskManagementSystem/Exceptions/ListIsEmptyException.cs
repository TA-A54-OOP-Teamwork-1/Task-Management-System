namespace TaskManagementSystem.Exceptions
{
    public class ListIsEmptyException : Exception
    {
        public ListIsEmptyException(string message) 
            : base(message)
        {
        }
    }
}

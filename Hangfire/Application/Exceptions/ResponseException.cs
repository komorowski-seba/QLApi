namespace Application.Exceptions
{
    public class ResponseException : Exception
    {
        public ResponseException(string message) : base(message)
        {
        }
    }
}
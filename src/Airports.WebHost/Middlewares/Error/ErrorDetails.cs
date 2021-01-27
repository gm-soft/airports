namespace Airports.WebHost.Middlewares.Error
{
    public class ErrorDetails
    {
        public ErrorDetails(int status, string message)
        {
            Status = status;
            Message = message;
        }

        public int Status { get; }

        public string Message { get; }
    }
}
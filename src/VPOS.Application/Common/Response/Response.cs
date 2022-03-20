namespace VPOS.Application.Common.Response
{
    public abstract class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public Response(bool success)
        {
            Success = success;
        }

        public Response(bool success, string message)
            : this(success)
        {
            Message = message;
        }
    }
}

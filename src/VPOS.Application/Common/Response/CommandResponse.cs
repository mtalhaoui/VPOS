namespace VPOS.Application.Common.Response
{
    public class CommandResponse : Response
    {
        public CommandResponse(bool success)
            : base(success)
        {
        }

        public CommandResponse(bool success, string message)
            : base(success, message)
        {
        }
    }
}

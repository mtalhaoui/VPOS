using System;

namespace VPOS.Domain.Exceptions
{
    public abstract class VPOSException : Exception
    {
        protected VPOSException(string message) : base(message)
        {
        }
    }
}

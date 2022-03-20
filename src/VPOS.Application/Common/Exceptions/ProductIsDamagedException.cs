using System;

namespace VPOS.Application.Common.Exceptions
{
    public class ProductIsDamagedException : Exception
    {
        public ProductIsDamagedException(string name) : base($"Product '{name}' is damaged and can\'t be sold.")
        {
        }
    }
}

using System;

namespace VPOS.Application.Common.Exceptions
{
    public class ProductAlreadySoldException : Exception
    {
        public ProductAlreadySoldException(string name) : base ($"Product '{name}' was already sold and is not in stock.")
        {
        }
    }
}

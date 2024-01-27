using System;

namespace Heinekamp.Application.Exceptions
{
    public class ApiExceptions : Exception
    {
        public ApiExceptions(string message) : base(message)
        {
        }
    }
}

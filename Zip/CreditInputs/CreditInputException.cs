using System;

namespace Zip.CreditInputs
{
    public class CreditInputException : Exception
    {
        public CreditInputException()
        {
        }

        public CreditInputException(string message) : base(message)
        {

        }
    }

    public class ImplementationException : Exception
    {
        public ImplementationException()
        {
        }
    }
}

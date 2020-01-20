using System;

namespace Zip.CreditCalculator
{
    public class InvalidCreditScoreException : Exception
    {
        public InvalidCreditScoreException()
        {
        }

        public InvalidCreditScoreException(string message) : base(message)
        {
        }
    }
}

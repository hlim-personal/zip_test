using System;

namespace Zip.CreditInputs
{
    public class CreditScoreCalculator : ICreditInputCalculator
    {
        public CreditScoreBands CreditScoreBand { get;}

        public CreditScoreCalculator(int creditScore)
        {
            if (creditScore < 0 || creditScore > 1000)
            {
                throw new CreditInputException("Invalid credit score input.");
            }
            else if (creditScore <= 450)
            {
                CreditScoreBand = CreditScoreBands.Ineligible;
            }
            else if (creditScore > 450 && creditScore <= 700)
            {
                CreditScoreBand = CreditScoreBands.Low;
            }
            else if (creditScore > 700 && creditScore <= 850)
            {
                CreditScoreBand = CreditScoreBands.Medium;
            }
            else if (creditScore > 850 && creditScore <= 1000)
            {
                CreditScoreBand = CreditScoreBands.High;
            }
        }

        public int GetScore()
        {
            switch (CreditScoreBand)
            {
                case CreditScoreBands.Ineligible:
                    throw new IneligibleCreditScoreException("Credit score is too low");
                case CreditScoreBands.Low:
                    return 1;
                case CreditScoreBands.Medium:
                    return 2;
                case CreditScoreBands.High:
                    return 3;
                default:
                    throw new ImplementationException();
            }
        }
    }

    public enum CreditScoreBands
    {
        Ineligible,     // 0   - 450
        Low,            // 451 - 700
        Medium,         // 701 - 850
        High            // 851 - 1000
    }

    public class IneligibleCreditScoreException : Exception
    {
        public IneligibleCreditScoreException()
        {
        }

        public IneligibleCreditScoreException(string message) : base(message)
        {
        }
    }
}

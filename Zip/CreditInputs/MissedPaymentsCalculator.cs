namespace Zip.CreditInputs
{
    public class MissedPaymentsCalculator : ICreditInputCalculator
    {
        public MissedPaymentsBands MissedPaymentsBand { get; }

        public MissedPaymentsCalculator(int missedPayments)
        {
            if (missedPayments < 0)
            {
                throw new CreditInputException("Invalid missed payments score");
            }
            else if (missedPayments == 0)
            {
                MissedPaymentsBand = MissedPaymentsBands.Zero;
            }
            else if (missedPayments == 1)
            {
                MissedPaymentsBand = MissedPaymentsBands.Low;
            }
            else if (missedPayments == 2)
            {
                MissedPaymentsBand = MissedPaymentsBands.Medium;
            }
            else if (missedPayments >= 3)
            {
                MissedPaymentsBand = MissedPaymentsBands.High;
            }
        }

        public int GetScore()
        {
            switch(MissedPaymentsBand)
            {
                case MissedPaymentsBands.Zero:
                    return 0;
                case MissedPaymentsBands.Low:
                    return -1;
                case MissedPaymentsBands.Medium:
                    return -3;
                case MissedPaymentsBands.High:
                    return -6;
                default:
                    throw new ImplementationException();
            }
        }
    }

    public enum MissedPaymentsBands
    {
        Zero,       // 0
        Low,        // 1
        Medium,     // 2
        High        // 3+
    }
}

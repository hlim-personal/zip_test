namespace Zip.CreditInputs
{
    public class CompletedPaymentsCalculator : ICreditInputCalculator
    {
        public CompletedPaymentsBands CompletedPaymentBand { get; }

        public CompletedPaymentsCalculator(int completedPayments)
        {
            if (completedPayments < 0)
            {
                throw new CreditInputException("Invalid completed payments score input.");
            }
            else if (completedPayments == 0)
            {
                CompletedPaymentBand = CompletedPaymentsBands.Zero;
            }
            else if (completedPayments == 1)
            {
                CompletedPaymentBand = CompletedPaymentsBands.Low;
            }
            else if (completedPayments == 2)
            {
                CompletedPaymentBand = CompletedPaymentsBands.Medium;
            }
            else if (completedPayments >= 3)
            {
                CompletedPaymentBand = CompletedPaymentsBands.High;
            }
        }

        public int GetScore()
        {
            switch (CompletedPaymentBand)
            {
                case CompletedPaymentsBands.Zero:
                    return 0;
                case CompletedPaymentsBands.Low:
                    return 2;
                case CompletedPaymentsBands.Medium:
                    return 3;
                case CompletedPaymentsBands.High:
                    return 4;
                default:
                    throw new ImplementationException();
            }
        }
    }
    

    public enum CompletedPaymentsBands
    {
        Zero,       // 0
        Low,        // 1
        Medium,     // 2
        High        // 3+
    }
}

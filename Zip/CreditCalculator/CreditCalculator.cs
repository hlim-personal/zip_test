using Zip.CreditInputs;

namespace Zip.CreditCalculator
{
    public class CreditCalculator : ICreditCalculator
    {
        public decimal CalculateCredit(Customer customer)
        {
            var creditScoreCalculator = new CreditScoreCalculator(customer.BureauScore);
            var missedPaymentsCalculator = new MissedPaymentsCalculator(customer.MissedPaymentCount);
            var completedPaymentsCalculator = new CompletedPaymentsCalculator(customer.CompletedPaymentCount);

            if (creditScoreCalculator.CreditScoreBand == CreditScoreBands.Ineligible)
            {
                throw new InvalidCreditScoreException("Customer's credit score is too low.");
            }

            var maximumPoints = creditScoreCalculator.GetScore() + missedPaymentsCalculator.GetScore() + completedPaymentsCalculator.GetScore();

            var ageAdjustedPoints = ApplyAgePointsCeiling(maximumPoints, customer.AgeInYears);

            return CalculateAvailableCreditFromPoints(ageAdjustedPoints);
        }

        int ApplyAgePointsCeiling(int maximumPoints, int customerAgeInYears)
        {
            var ageBracketCalculator = new AgeBracketCalculator(customerAgeInYears);

            return maximumPoints > ageBracketCalculator.GetScore()
                ? ageBracketCalculator.GetScore()
                : maximumPoints;
        }

        decimal CalculateAvailableCreditFromPoints(int points)
        {
            if (points <= 0)
            {
                return 0;
            }

            switch(points)
            {
                case 1:
                    return 100;
                case 2:
                    return 200;
                case 3:
                    return 300;
                case 4:
                    return 400;
                case 5:
                    return 500;
                case 6:
                default:
                    return 600;
            }
        }
    }
}

using Xunit;
using Zip.CreditInputs;
using Zip.CreditCalculator;

namespace CreditCalculatorTests.CreditCalculatorTests
{
    public class CreditCalculatorTests
    {
        [Fact]
        public void CalculateCredit_Exception_CreditScore()
        {
            var customer = new Customer(300, 2, 1, 44);
            var calculator = new CreditCalculator();
            Assert.Throws<InvalidCreditScoreException>(() => calculator.CalculateCredit(customer));
        }

        [Fact]
        public void Calculate_Credit_John()
        {
            var john = new Customer(750, 1, 4, 29);
            var calculator = new CreditCalculator();
            Assert.Equal(400, calculator.CalculateCredit(john));
        }
    }
}

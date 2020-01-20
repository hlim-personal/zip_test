using Xunit;
using Zip.CreditInputs;

namespace CreditCalculatorTests.CreditInputTests
{
    public class CompletedPaymentsCalculatorTests
    {
        [Fact]
        public void Constructor_Exception_TooLow()
        {
            Assert.Throws<CreditInputException>(() => new CompletedPaymentsCalculator(-1));
        }

        [Fact]
        public void Constructor_SetCompletedPaymentsBand_Zero()
        {
            var calculator = new CompletedPaymentsCalculator(0);
            Assert.Equal(CompletedPaymentsBands.Zero, calculator.CompletedPaymentBand);
        }

        [Fact]
        public void GetScore_Zero()
        {
            var calculator = new CompletedPaymentsCalculator(0);
            Assert.Equal(0, calculator.GetScore());
        }

        [Fact]
        public void Constructor_SetCompletedPaymentsBand_Low()
        {
            var calculator = new CompletedPaymentsCalculator(1);
            Assert.Equal(CompletedPaymentsBands.Low, calculator.CompletedPaymentBand);
        }

        [Fact]
        public void GetScore_Low()
        {
            var calculator = new CompletedPaymentsCalculator(1);
            Assert.Equal(2, calculator.GetScore());
        }

        [Fact]
        public void Constructor_SetCompletedPaymentsBand_Medium()
        {
            var calculator = new CompletedPaymentsCalculator(2);
            Assert.Equal(CompletedPaymentsBands.Medium, calculator.CompletedPaymentBand);
        }

        [Fact]
        public void GetScore_Medium()
        {
            var calculator = new CompletedPaymentsCalculator(2);
            Assert.Equal(3, calculator.GetScore());
        }

        [Fact]
        public void Constructor_SetCompletedPaymentsBand_High()
        {
            var calculatorFloor = new CompletedPaymentsCalculator(3);
            Assert.Equal(CompletedPaymentsBands.High, calculatorFloor.CompletedPaymentBand);

            var calculatorFloating = new CompletedPaymentsCalculator(6);
            Assert.Equal(CompletedPaymentsBands.High, calculatorFloating.CompletedPaymentBand);
        }

        [Fact]
        public void GetScore_High()
        {
            var calculator = new CompletedPaymentsCalculator(5);
            Assert.Equal(4, calculator.GetScore());
        }
    }
}

using Xunit;
using Zip.CreditInputs;

namespace CreditCalculatorTests.CreditInputTests
{
    public class MissedPaymentCalculatorTests
    {
        [Fact]
        public void Constructor_Exception_TooLow()
        {
            Assert.Throws<CreditInputException>(() => new MissedPaymentsCalculator(-1));
        }

        [Fact]
        public void Constructor_SetMissedPaymentsBand_Zero()
        {
            var calculator = new MissedPaymentsCalculator(0);
            Assert.Equal(MissedPaymentsBands.Zero, calculator.MissedPaymentsBand);
        }

        [Fact]
        public void GetScore_Zero()
        {
            var calculator = new MissedPaymentsCalculator(0);
            Assert.Equal(0, calculator.GetScore());
        }

        [Fact]
        public void Constructor_SetMissedPaymentsBand_Low()
        {
            var calculator = new MissedPaymentsCalculator(1);
            Assert.Equal(MissedPaymentsBands.Low, calculator.MissedPaymentsBand);
        }

        [Fact]
        public void GetScore_Low()
        {
            var calculator = new MissedPaymentsCalculator(1);
            Assert.Equal(-1, calculator.GetScore());
        }

        [Fact]
        public void Constructor_SetMissedPaymentsBand_Medium()
        {
            var calculator = new MissedPaymentsCalculator(2);
            Assert.Equal(MissedPaymentsBands.Medium, calculator.MissedPaymentsBand);
        }

        [Fact]
        public void GetScore_Medium()
        {
            var calculator = new MissedPaymentsCalculator(2);
            Assert.Equal(-3, calculator.GetScore());
        }

        [Fact]
        public void Constructor_SetMissedPaymentsBand_High()
        {
            // floor ceil
            var calculatorFloor = new MissedPaymentsCalculator(3);
            Assert.Equal(MissedPaymentsBands.High, calculatorFloor.MissedPaymentsBand);
            
            var calculatorFloating = new MissedPaymentsCalculator(5);
            Assert.Equal(MissedPaymentsBands.High, calculatorFloor.MissedPaymentsBand);
        }

        [Fact]
        public void GetScore_High()
        {
            var calculator = new MissedPaymentsCalculator(5);
            Assert.Equal(-6, calculator.GetScore());
        }
    }
}

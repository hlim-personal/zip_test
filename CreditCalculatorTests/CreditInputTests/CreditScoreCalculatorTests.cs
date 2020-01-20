using Xunit;
using Zip.CreditInputs;

namespace CreditCalculatorTests.CreditInputTests
{
    public class CreditScoreCalculatorTests
    {
        [Fact]
        public void Constructor_Exception_TooLow()
        {
            Assert.Throws<CreditInputException>(() => new CreditScoreCalculator(-1));
        }

        [Fact]
        public void Constructor_Exception_TooHigh()
        {
            Assert.Throws<CreditInputException>(() => new CreditScoreCalculator(1001));
        }

        [Fact]
        public void Constructor_SetCreditStoreBand_Ineligible()
        {
            var calculatorFloor = new CreditScoreCalculator(0);
            Assert.Equal(CreditScoreBands.Ineligible, calculatorFloor.CreditScoreBand);

            var calculatorCeiling = new CreditScoreCalculator(450);
            Assert.Equal(CreditScoreBands.Ineligible, calculatorCeiling.CreditScoreBand);
        }

        [Fact]
        public void GetScore_Ineligible()
        {
            var calculator = new CreditScoreCalculator(200);
            Assert.Throws<IneligibleCreditScoreException>(() => calculator.GetScore());
        }

        [Fact]
        public void Constructor_SetCreditStoreBand_Low()
        {
            var calculatorFloor = new CreditScoreCalculator(451);
            Assert.Equal(CreditScoreBands.Low, calculatorFloor.CreditScoreBand);

            var calculatorCeiling = new CreditScoreCalculator(700);
            Assert.Equal(CreditScoreBands.Low, calculatorCeiling.CreditScoreBand);
        }

        [Fact]
        public void GetScore_Low()
        {
            var calculator = new CreditScoreCalculator(600);
            Assert.Equal(1, calculator.GetScore());
        }

        [Fact]
        public void Constructor_SetCreditStoreBand_Medium()
        {
            var calculatorFloor = new CreditScoreCalculator(701);
            Assert.Equal(CreditScoreBands.Medium, calculatorFloor.CreditScoreBand);

            var calculatorCeiling = new CreditScoreCalculator(850);
            Assert.Equal(CreditScoreBands.Medium, calculatorCeiling.CreditScoreBand);
        }

        [Fact]
        public void GetScore_Medium()
        {
            var calculator = new CreditScoreCalculator(800);
            Assert.Equal(2, calculator.GetScore());
        }

        [Fact]
        public void Constructor_SetCreditStoreBand_High()
        {
            var calculatorFloor = new CreditScoreCalculator(851);
            Assert.Equal(CreditScoreBands.High, calculatorFloor.CreditScoreBand);

            var calculatorCeiling = new CreditScoreCalculator(1000);
            Assert.Equal(CreditScoreBands.High, calculatorCeiling.CreditScoreBand);
        }

        [Fact]
        public void GetScore_High()
        {
            var calculator = new CreditScoreCalculator(925);
            Assert.Equal(3, calculator.GetScore());
        }
    }
}

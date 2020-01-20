using Xunit;
using Zip.CreditInputs;

namespace CreditCalculatorTests.CreditInputTests
{
    public class AgeBracketCalculatorTests
    {
        [Fact]
        public void Constructor_Exception_TooLow()
        {
            Assert.Throws<CreditInputException>(() => new AgeBracketCalculator(17));
        }

        [Fact]
        public void Constructor_SetAgeBracketBand_YoungAdult()
        {
            var calculatorFloor = new AgeBracketCalculator(18);
            Assert.Equal(AgeBracketBands.YoungAdult, calculatorFloor.AgeBracketBand);

            var calculatorCeiling = new AgeBracketCalculator(25);
            Assert.Equal(AgeBracketBands.YoungAdult, calculatorCeiling.AgeBracketBand);
        }

        [Fact]
        public void GetMaxScore_YoungAdult()
        {
            var calculator = new AgeBracketCalculator(22);
            Assert.Equal(3, calculator.GetScore());
        }

        [Fact]
        public void Constructor_SetAgeBracketBand_Adult()
        {
            var calculatorFloor = new AgeBracketCalculator(26);
            Assert.Equal(AgeBracketBands.Adult, calculatorFloor.AgeBracketBand);

            var calculatorCeiling = new AgeBracketCalculator(35);
            Assert.Equal(AgeBracketBands.Adult, calculatorCeiling.AgeBracketBand);
        }

        [Fact]
        public void GetMaxScore_Adult()
        {
            var calculator = new AgeBracketCalculator(30);
            Assert.Equal(4, calculator.GetScore());
        }

        [Fact]
        public void Constructor_SetAgeBracketBand_MiddleAged()
        {
            var calculatorFloor = new AgeBracketCalculator(36);
            Assert.Equal(AgeBracketBands.MiddleAged, calculatorFloor.AgeBracketBand);

            var calculatorCeiling = new AgeBracketCalculator(50);
            Assert.Equal(AgeBracketBands.MiddleAged, calculatorCeiling.AgeBracketBand);
        }

        [Fact]
        public void GetMaxScore_MiddleAged()
        {
            var calculator = new AgeBracketCalculator(42);
            Assert.Equal(5, calculator.GetScore());
        }

        [Fact]
        public void Constructor_SetAgeBracketBand_Senior()
        {
            var calculatorFloor = new AgeBracketCalculator(51);
            Assert.Equal(AgeBracketBands.Senior, calculatorFloor.AgeBracketBand);

            var calculatorCeiling = new AgeBracketCalculator(75);
            Assert.Equal(AgeBracketBands.Senior, calculatorCeiling.AgeBracketBand);
        }

        [Fact]
        public void GetMaxScore_Senior()
        {
            var calculator = new AgeBracketCalculator(66);
            Assert.Equal(6, calculator.GetScore());
        }
    }
}

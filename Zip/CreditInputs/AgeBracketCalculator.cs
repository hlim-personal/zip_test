namespace Zip.CreditInputs
{
    public class AgeBracketCalculator : ICreditInputCalculator
    {
        public AgeBracketBands AgeBracketBand { get; }

        public AgeBracketCalculator(int age)
        {
            if (age < 18)
            {
                throw new CreditInputException("Invalid age input.");
            }
            else if (age <= 25)
            {
                AgeBracketBand = AgeBracketBands.YoungAdult;
            }
            else if (age > 25 && age <= 35)
            {
                AgeBracketBand = AgeBracketBands.Adult;
            }
            else if (age > 35 && age <= 50)
            {
                AgeBracketBand = AgeBracketBands.MiddleAged;
            }
            else if (age > 50)
            {
                AgeBracketBand = AgeBracketBands.Senior;
            }
        }

        public int GetScore()
        {
            switch(AgeBracketBand)
            {
                case AgeBracketBands.YoungAdult:        
                    return 3;
                case AgeBracketBands.Adult:
                    return 4;
                case AgeBracketBands.MiddleAged:
                    return 5;
                case AgeBracketBands.Senior:
                    return 6;
                default:
                    throw new ImplementationException();
            }
        }
    }

    public enum AgeBracketBands
    {
        YoungAdult,     // 18-25
        Adult,          // 26-35
        MiddleAged,     // 36-50
        Senior          // 51+
    }
}

using static CSharp8.TuplePattern.RockPaperScissorType;

namespace CSharp8
{
    public class PatternMatching
    {
        // C# 7.0

        // C# 8.0
        public void Demo()
        {
            var (first, second) = new TuplePattern.RockPaperScissorsCombine();

            SwitchPattern.GetRainbowColor1(SwitchPattern.Rainbow.Red);
            PropertyPattern.GetTax(new PropertyPattern.Address { State = "MN", ZipCode = "100" });
            TuplePattern.RockPaperScissors(Rock, Paper);
            TuplePattern.RockPaperScissors(new TuplePattern.RockPaperScissorsCombine());
        }
    }
}

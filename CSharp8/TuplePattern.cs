using static CSharp8.TuplePattern.RockPaperScissorType;

namespace CSharp8
{
    public class TuplePattern
    {
        public static string RockPaperScissors(RockPaperScissorType first, RockPaperScissorType second)
            => (first, second) switch
            {
                (Rock, Paper) => "rPaper wins.",
                (Rock, Scissors) => "Rock wins.",
                (Paper, Rock) => "Paper wins.",
                (Paper, Scissors) => "pScissors wins.",
                (Scissors, Rock) => "Rock wins.",
                (Scissors, Paper) => "Scissors wins.",
                (_, _) => "tie"
            };

        public enum RockPaperScissorType
        { 
            Rock,
            Paper,
            Scissors
        }

        public class RockPaperScissorsCombine
        { 
            public RockPaperScissorType Frist { get; set; }
            public RockPaperScissorType Seconde { get; set; }

            public void Deconstruct(out RockPaperScissorType first, out RockPaperScissorType second) =>
            (first, second) = (Frist, Seconde);
        }

        public static string RockPaperScissors(RockPaperScissorsCombine combine)
            => combine switch
            {
                (Rock, Paper) => "rPaper wins.",
                (Rock, Scissors) => "Rock wins.",
                (Paper, Rock) => "Paper wins.",
                (Paper, Scissors) => "pScissors wins.",
                (Scissors, Rock) => "Rock wins.",
                (Scissors, Paper) => "Scissors wins.",
                (_, _) => "tie"
            };
    }
}

using static CSharp8.TuplePattern.RockPaperScissorType;

namespace CSharp8
{
    public class TuplePattern
    {
        public static string RockPaperScissors(RockPaperScissorType first, RockPaperScissorType second)
            => (first, second) switch
            {
                (Rock, Paper) => "rock is covered by paper. Paper wins.",
                (Rock, Scissors) => "rock breaks scissors. Rock wins.",
                (Paper, Rock) => "paper covers rock. Paper wins.",
                (Paper, Scissors) => "paper is cut by scissors. Scissors wins.",
                (Scissors, Rock) => "scissors is broken by rock. Rock wins.",
                (Scissors, Paper) => "scissors cuts paper. Scissors wins.",
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
                (Rock, Paper) => "rock is covered by paper. Paper wins.",
                (Rock, Scissors) => "rock breaks scissors. Rock wins.",
                (Paper, Rock) => "paper covers rock. Paper wins.",
                (Paper, Scissors) => "paper is cut by scissors. Scissors wins.",
                (Scissors, Rock) => "scissors is broken by rock. Rock wins.",
                (Scissors, Paper) => "scissors cuts paper. Scissors wins.",
                (_, _) => "tie"
            };
    }
}

using System.Windows.Forms;

namespace LionRacingGame
{
    public class Sukhraj : Punter
    {
        public Sukhraj(Bet bet, Label MaximumBet, int Cash, Label label) : base(bet, MaximumBet, Cash, label)
        {
        }

        public override void setPunterName()
        {
            Name = "Sukhraj";
        }
    }
}

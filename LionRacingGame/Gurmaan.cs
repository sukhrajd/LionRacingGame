using System.Windows.Forms;

namespace LionRacingGame
{
    public class Gurmaan : Punter
    {
        public Gurmaan(Bet bet, Label MaximumBet, int Cash, Label label) : base(bet, MaximumBet, Cash, label)
        {
        }

        public override void setPunterName()
        {
            Name = "Gurmaan";
        }
    }
}

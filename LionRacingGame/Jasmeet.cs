using System.Windows.Forms;

namespace LionRacingGame
{
    public class Jasmeet : Punter
    {
        public Jasmeet(Bet MyBet, Label MaximumBet, int Cash, Label MyLabel) : base(MyBet, MaximumBet, Cash, MyLabel)
        {
        }

        public override void setPunterName()
        {
            Name = "Jasmeet";
        }
    }
}

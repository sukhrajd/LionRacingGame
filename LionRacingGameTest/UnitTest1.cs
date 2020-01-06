using LionRacingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace LionRacingGameTest
{
    [TestClass]
    public class UnitTest1
    {
        Factory pFactory = new Factory();
        Punter Jasmeet;
        Lion[] Lions = new Lion[2];

        [TestMethod]
        public void TestWinnerOutcome()
        {
            Lion.StartingPosition1 = 0;
            Lion.RacetrackLength1 = 50;
            int BettingAmount = 45;
            int LionNumber = 1;
            int expectedWin = 90;
            int expectedLose = 0;
            Lions[0] = new Lion() { LionPictureBox = null };
            Lions[1] = new Lion() { LionPictureBox = null };
            Jasmeet = pFactory.getPunter("Jasmeet", null, null);
            Jasmeet.Cash = BettingAmount;
            Jasmeet.PlaceBet((int)BettingAmount, LionNumber);

            bool nowin = true;
            int win = -1;
            while (nowin)
            {
                for (int i = 0; i < Lions.Length; i++)
                {
                    if (Lion.Run(Lions[i]))
                    {
                        win = i + 1;
                        Jasmeet.Collect(win);
                        nowin = false;

                    }
                }
            }
            if (Jasmeet.bet.LionNum == win)
            {
                Assert.AreEqual(expectedWin, Jasmeet.Cash, "Account not credited correctly");
            }
            if (Jasmeet.bet.LionNum != win)
            {
                Assert.AreEqual(expectedLose, Jasmeet.Cash, "Account not debited correctly");

            }
        }
    }

}

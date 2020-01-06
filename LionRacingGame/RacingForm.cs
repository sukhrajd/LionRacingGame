using System;
using System.Windows.Forms;

namespace LionRacingGame
{
    public partial class RacingForm : Form
    {
        Lion[] Lions = new Lion[4];

        Factory pFactory = new Factory();
        Punter[] punters = new Punter[3];

        public RacingForm()
        {
            InitializeComponent();
            SetupRaceTrack();
        }

        private void SetupRaceTrack()
        {

            Lion.StartingPosition1 = Lion1.Right - racetrack.Left;
            Lion.RacetrackLength1 = racetrack.Size.Width - 70; //fixing length of race - till finish line

            Lions[0] = new Lion() { LionPictureBox = Lion1 };
            Lions[1] = new Lion() { LionPictureBox = Lion2 };
            Lions[2] = new Lion() { LionPictureBox = Lion3 };
            Lions[3] = new Lion() { LionPictureBox = Lion4 };

            punters[0] = pFactory.getPunter("Jasmeet", MaximumBet, JasmeetBet); //getting Jasmeet object from factory class
            punters[1] = pFactory.getPunter("Sukhraj", MaximumBet, SukhrajBet); //getting Sukhraj object from factory class
            punters[2] = pFactory.getPunter("Gurmaan", MaximumBet, GurmaanBet); //getting Gurmaan object from factory class


            foreach (Punter punter in punters)
            {
                punter.UpdateLabels();
            }
        }

        private void JasmeetButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[0].Cash);
        }

        private void SukhrajButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[1].Cash);
        }

        private void GurmaanButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[2].Cash);
        }

        private void setMaximumBetTextLabel(int Cash)
        {
            MaximumBet.Text = String.Format("Maximum Bet: ${0}", Cash);
        }

        // setting the bet for each Punter and updating labels respectively
        private void Bets_Click(object sender, EventArgs e)
        {
            int PunterNum = 0;

            if (JasmeetButton.Checked)
            {
                PunterNum = 0;
            }
            if (SukhrajRButton.Checked)
            {
                PunterNum = 1;
            }
            if (GurmaanRButton.Checked)
            {
                PunterNum = 2;
            }

            punters[PunterNum].PlaceBet((int)BettingAmount.Value, (int)LionNumber.Value);
            punters[PunterNum].UpdateLabels();
        }

        private void race_Click(object sender, EventArgs e)
        {
            bool NoWinner = true;
            int winningLion;
            race.Enabled = false; //disable start race button

            while (NoWinner)
            { // loop until we have a winner
                Application.DoEvents();
                for (int i = 0; i < Lions.Length; i++)
                {
                    if (Lion.Run(Lions[i]))
                    {
                        winningLion = i + 1;
                        NoWinner = false;
                        MessageBox.Show("We have a winner - Lion #" + winningLion);
                        foreach (Punter punter in punters)
                        {
                            if (punter.bet != null)
                            {
                                punter.Collect(winningLion); //give double amount to all who've won or deduce betted amount
                                punter.bet = null;
                                punter.UpdateLabels();
                            }
                        }
                        foreach (Lion Lion in Lions)
                        {
                            Lion.TakeStartingPosition();
                        }
                        break;
                    }
                }
            }
            if (punters[0].busted && punters[1].busted && punters[2].busted)
            {  //stop punters from betting if they run out of cash
                String message = "Do you want to Play Again?";
                String title = "GAME OVER!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    SetupRaceTrack(); //restart game
                }
                else
                {
                    this.Close();
                }

            }
            race.Enabled = true; //enable race button 
        }

    }
}

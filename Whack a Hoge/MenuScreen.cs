using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whack_a_Hoge
{
    public partial class MenuScreen : Form
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        //Open Game Screen
        private void gameButton_Click(object sender, EventArgs e)
        {
            //creates a variable out of the next screen. "this" refers to the currently open screen, which hides. Then shows the next screen.
            GameScreen gameScreen = new GameScreen();
            this.Hide();
            gameScreen.Show();     
        }

        //Leaderboard button
        private void leaderboardButton_Click(object sender, EventArgs e)
        {
            //creates a variable out of the next screen. "this" refers to the currently open screen, which hides. Then shows the next screen.
            LeaderboardScreen leaderboardScreen = new LeaderboardScreen();
            this.Hide();
            leaderboardScreen.Show();           
        }

        //exit button
        private void exitButton_Click(object sender, EventArgs e)
        {           
            Environment.Exit(1);
        }

        //Tutorial Button
        private void tutorialButton_Click(object sender, EventArgs e)
        {
            //creates a variable out of the next screen. "this" refers to the currently open screen, which hides. Then shows the next screen.
            TutorialScreen tutorialScreen = new TutorialScreen();
            this.Hide();
            tutorialScreen.Show();
        }

        //easter egg for when hogan is clicked
        private void Hur(object sender, EventArgs e)
        {
            exitButton.Visible = false;
            label1.Text = "NO ESCAPE";
            label2.Visible = false;
            BackColor = Color.Black;
            SoundPlayer simpleSound = new SoundPlayer("Microsoft Windows XP Error - Sound Effect (HD).wav");
            simpleSound.Play();
        }
    }
}

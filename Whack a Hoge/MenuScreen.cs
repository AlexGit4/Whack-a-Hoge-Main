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
        //checks if music is already playing, to prevent overlap while switching forms
        public static bool isMusicPlaying = false;

        public MenuScreen()
        {
            InitializeComponent();
            //if music isnt currently playing, then start playing it through media player. Play count is set high so that it loops practically infinitely
            if (isMusicPlaying == false)
            {
                MusicPlay.URL = @"MainTrack.wav";
                MusicPlay.settings.playCount = 9999;
                MusicPlay.settings.volume = 10;
                MusicPlay.Visible = false;
                MusicPlay.Ctlcontrols.play();
                
            }
            

        }

        //Open Game Screen
        private void gameButton_Click(object sender, EventArgs e)
        {
            //Plays click sound.
            SoundPlayer click = new SoundPlayer("ui-click-43196.wav");
            click.Play();
            //creates a variable out of the next screen. "this" refers to the currently open screen, which hides. Then shows the next screen.
            GameScreen gameScreen = new GameScreen();
            this.Hide();
            gameScreen.Show();     
        }

        //Leaderboard button
        private void leaderboardButton_Click(object sender, EventArgs e)
        {
            //Plays click sound.
            SoundPlayer click = new SoundPlayer("ui-click-43196.wav");
            click.Play();
            //creates a variable out of the next screen. "this" refers to the currently open screen, which hides. Then shows the next screen.
            LeaderboardScreen leaderboardScreen = new LeaderboardScreen();
            this.Hide();
            leaderboardScreen.Show();           
        }

        //exit button
        private void exitButton_Click(object sender, EventArgs e)
        {            
            Environment.Exit(0);
        }

        //Tutorial Button
        private void tutorialButton_Click(object sender, EventArgs e)
        {
            //Plays click sound.
            SoundPlayer click = new SoundPlayer("ui-click-43196.wav");
            click.Play();
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

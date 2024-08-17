using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whack_a_Hoge
{
    public partial class TutorialScreen : Form
    {
        public TutorialScreen()
        {
            InitializeComponent();
        }

        //back button for returning to menu
        private void backButton_Click(object sender, EventArgs e)
        {
            //sets the music playing to true, to avoid overlap.
            MenuScreen.isMusicPlaying = true;
            //Plays click sound.
            SoundPlayer click = new SoundPlayer("ui-click-43196.wav");
            click.Play();
            //creates a variable out of the next screen. "this" refers to the currently open screen, which hides. Then shows the next screen.
            MenuScreen menuScreen = new MenuScreen();
            this.Hide();
            menuScreen.Show();
            this.Close();
        }      
    }
}

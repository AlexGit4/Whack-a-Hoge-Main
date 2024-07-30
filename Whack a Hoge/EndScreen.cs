using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whack_a_Hoge
{
    public partial class EndScreen : Form
    {
        public string Username;
        int Score = GameScreen.Hits;
        public EndScreen()
        {
            InitializeComponent();
            ;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Username = textBox1.Text;
            using (StreamWriter sw = new StreamWriter("Leaderboard.txt", true))
            {
                sw.WriteLine(Username + ": " + Score + " Hits");

            }

            MenuScreen menuScreen = new MenuScreen(); //creates a variable out of the next screen
            this.Hide(); //"this" refers to the currently open screen.
            menuScreen.Show(); //shows the next screen
            this.Close();
        }


    }
}

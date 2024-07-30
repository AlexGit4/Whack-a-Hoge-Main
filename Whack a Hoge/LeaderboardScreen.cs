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
using System.Net.Http;

namespace Whack_a_Hoge
{
    public partial class LeaderboardScreen : Form
    {
        public LeaderboardScreen()
        {
            InitializeComponent();

            using (StreamReader sr = new StreamReader("Leaderboard.txt", true))
            {
                
                List<string> Leaderboard = new List<string>();
                //for (int i = 0; i < 10; i++)
                //{                                    
                //    string line = sr.ReadLine();
                //    Leaderboard[i] = line;

                //}
                //label2.Text = Leaderboard[3];
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Leaderboard.Add(line);
                }
                for (int i = 0; i < Leaderboard.Count; i++)
                {
                    label2.Text = Leaderboard[3];
                    label3.Text = Leaderboard[2];
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuScreen menuScreen = new MenuScreen(); //creates a variable out of the next screen
            this.Hide(); //"this" refers to the currently open screen.
            menuScreen.Show(); //shows the next screen
            this.Close();
        }
    }
}

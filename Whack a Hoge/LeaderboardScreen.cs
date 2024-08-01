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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;




namespace Whack_a_Hoge
{
    public partial class LeaderboardScreen : Form
    {
        public LeaderboardScreen()
        {
            InitializeComponent();

            using (StreamReader sr = new StreamReader("Leaderboard.txt", true))
            {
                //Create the lists
                List<string> Names = new List<string>();
                List<int> Scores = new List<int>();
                List<string> Leaderboard = new List<string>();
                
                
                // set line as a string
                string line;
                //while the line contains something
                while ((line = sr.ReadLine()) != null)
                {
                    //Split the line into an array
                    string[] data = (Convert.ToString(line).Split('-'));
                    //Add the score to the list
                    Scores.Add(Convert.ToInt32(data[1]));
                    //add Names to the list
                    Names.Add(data[0]);
                }
                //Put list to array
                string[] NameArray = Names.ToArray();
                int[] ScoreArray = Scores.ToArray();
                //Sort by score, then reverse
                Array.Sort(ScoreArray, NameArray);
                Array.Reverse(ScoreArray);
                Array.Reverse(NameArray);
                //set text box for the textbox writer class
                Console.SetOut(new RichTextBoxWriter(richTextBox1));
                //Write out the scores and names onto the textbox
                for (int i = 0; i < ScoreArray.Length; i++)
                {
                    
                    Console.Write((i+1) + ": " + NameArray[i] + " " + ScoreArray[i]);
                    Console.WriteLine();
                }
                




            }
        }

        
        //class for writing in a textbox
        public class RichTextBoxWriter : TextWriter
        {
            System.Windows.Forms.RichTextBox _output = null;

            public RichTextBoxWriter(System.Windows.Forms.RichTextBox output)
            {
                _output = output;
            }

            public override void Write(char value)
            {
                base.Write(value);
                _output.AppendText(value.ToString());

            }

            public override Encoding Encoding
            {
                get { return System.Text.Encoding.UTF8; }
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

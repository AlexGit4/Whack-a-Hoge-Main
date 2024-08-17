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
                //Set line as a string for reading lines of the text file
                string line;
                //while the line contains something...
                while ((line = sr.ReadLine()) != null)
                {
                    //Split the line into an array separated by the dash. Leaderboard file contains lines with "name-score".
                    string[] data = (Convert.ToString(line).Split('-'));
                    //Add the score to the score list and add names to the names list
                    Scores.Add(Convert.ToInt32(data[1]));
                    Names.Add(data[0]);
                }
                //Put lists to arrays so we can sort them
                string[] nameArray = Names.ToArray();
                int[] scoreArray = Scores.ToArray();
                //Sort both arrays by score. Then reverse, due to the sort being in ascending order
                Array.Sort(scoreArray, nameArray);
                Array.Reverse(scoreArray);
                Array.Reverse(nameArray);
                //These integers are just to store previous values, so that if the next score is the same, the placing will be the same.
                int oldPlacing = 0;
                int prevScore = -1;
                //set text box for the textbox writer class. Console output will go to this textbox.
                Console.SetOut(new RichTextBoxWriter(richTextBox1));
                //Write out the scores and names onto the textbox, from console output.
                for (int i = 0; i < scoreArray.Length; i++)
                {
  
                    //Checks if the score is the same as the previous entry. This is for cases where players have equal scores.
                    if (scoreArray[i] != prevScore)
                    {
                        //if the scores are not the same, write the placing as the previous + 1
                        Console.Write((oldPlacing + 1) + GetPlacingSuffix(oldPlacing+1) + ": " + nameArray[i] + " " + scoreArray[i]);
                        Console.WriteLine();
                        //add to previous placing
                        oldPlacing++;
                    }
                    //If they are the same, it writes them in the same placing.
                    else
                    {
                        Console.Write((oldPlacing) + GetPlacingSuffix(oldPlacing) + ": " + nameArray[i] + " " + scoreArray[i]);
                        Console.WriteLine();
                    }
                    //Sets previous score to current score.
                    prevScore = scoreArray[i];
                }
            }

            //function for Getting the suffix of the placing (st, nd, rd, th)
            string GetPlacingSuffix(int placing)
            {
                //by default th, most common
                string placingSuffix = "th";
                //Modulo by 10 divides and returns remainder. In this case it will return last digit of placing. This is for numbers like 21, or 11.
                int lastDigit = placing % 10;
                //it's different for the teens, eg 11th not 11st also 111th, 313th etc. So we have to check those too. eg for 113 this will be 13.
                int teens = placing % 100;  

                //checks each number for last digit and checks that it isnt a teen.
                if (lastDigit == 1 && teens != 11)
                {
                    placingSuffix = "st";
                }

                else if (lastDigit == 2 && teens != 12)
                {
                    placingSuffix = "nd";
                }

                else if (lastDigit == 3 && teens != 13)
                {
                    placingSuffix = "rd";
                }
                //returns suffix
                return placingSuffix;
            }
        }
   
        //Class for writing in a textbox using console output. I found this online, and it will make it so that the placings can be separated by lines
        public class RichTextBoxWriter : TextWriter
        {
            System.Windows.Forms.RichTextBox _output = null;

            //sets output to be a richtextbox
            public RichTextBoxWriter(System.Windows.Forms.RichTextBox output)
            {
                _output = output;
            }

            //writes into the text box as if it were a console.
            public override void Write(char value)
            {
                base.Write(value);
                _output.AppendText(value.ToString());

            }

            //overrides the normal text box writing method
            public override Encoding Encoding
            {
                get { return System.Text.Encoding.UTF8; }
            }
        }


        private void backButton_Click(object sender, EventArgs e)
        {
            //creates a variable out of the next screen. "this" refers to the currently open screen, which hides. Then shows the next screen.
            MenuScreen menuScreen = new MenuScreen(); 
            this.Hide();
            menuScreen.Show();
            this.Close();
        }
    }
}
